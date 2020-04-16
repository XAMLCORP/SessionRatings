using Gaming.Foundation.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Foundation.DataAccess
{
    public class Repository<T> : Interfaces.IRepository<T> where T : TableEntity, new()
    {
        private CloudStorageAccount _storageAccount;
        private CloudTableClient _tableClient;
        private CloudTable _storageTable;

        public void SetStorageAccount(string connectionString)
        {
            _storageAccount = CloudStorageAccount.Parse(connectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();
            var table = _tableClient.GetTableReference(typeof(T).Name);
            _storageTable = table;
            //AsyncHelper.RunSync(() => CreateTableAsync());
        }

        public IUnitOfWork Scope { get; set; }

        public async Task<T> AddAsync(T entity)
        {
            var entityToInsert = entity as BaseEntity;
            entityToInsert.CreatedDate = DateTime.UtcNow;
            entityToInsert.UpdatedDate = entityToInsert.CreatedDate;
            var insertOperation = TableOperation.Insert(entity);
            var result = await ExecuteAsync(insertOperation);
            return result.Result as T;
        }

        public async Task CreateTableAsync()
        {
            var table = _tableClient.GetTableReference(typeof(T).Name);
            await table.CreateIfNotExistsAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var entityToDelete = entity as BaseEntity;
            entityToDelete.UpdatedDate = DateTime.UtcNow;
            entityToDelete.IsDeleted = true;
            var deleteOperation = TableOperation.Replace(entityToDelete);
            await ExecuteAsync(deleteOperation);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var query = new TableQuery<T>();
            TableContinuationToken tableContinuationToken = null;
            var result = await _storageTable.ExecuteQuerySegmentedAsync(query, tableContinuationToken);
            return result.Results as IEnumerable<T>;
        }

        public async Task<IEnumerable<T>> FindAllByPartitionKeyAsync(string partitionKey)
        {
            var query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            TableContinuationToken tableContinuationToken = null;
            var result = await _storageTable.ExecuteQuerySegmentedAsync(query, tableContinuationToken);
            return result.Results as IEnumerable<T>;
        }

        public async Task<T> FindAsync(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var result = await _storageTable.ExecuteAsync(retrieveOperation);
            return result.Result as T;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entityToUpdate = entity as BaseEntity;
            entityToUpdate.UpdatedDate = DateTime.UtcNow;
            var updateOperation = TableOperation.Replace(entity);
            var result = await ExecuteAsync(updateOperation);
            return result.Result as T;
        }

        public async Task<T> SaveAsync(T entity)
        {
            var entityToUpdate = entity as BaseEntity;
            entityToUpdate.UpdatedDate = DateTime.UtcNow;
            var saveOperation = TableOperation.InsertOrMerge(entity);
            var result = await ExecuteAsync(saveOperation);
            return result.Result as T;
        }

        private async Task<TableResult> ExecuteAsync(TableOperation operation)
        {
            TableResult result = null;
            if (operation.OperationType != TableOperationType.InsertOrMerge)
            {
                var rollbackAction = CreateRollbackAction(operation);
                result = await _storageTable.ExecuteAsync(operation);
                Scope.RollbackActions.Enqueue(rollbackAction);
            }
            else
                result = await _storageTable.ExecuteAsync(operation);
            return result;
        }

        private async Task<Action> CreateRollbackAction(TableOperation operation)
        {
            if (operation.OperationType == TableOperationType.Retrieve)
                return null;

            switch (operation.OperationType)
            {
                case TableOperationType.Insert:
                    return async () => await UndoInsertOperationAsync(_storageTable, operation.Entity);
                case TableOperationType.Delete:
                    return async () => await UndoDeleteOperation(_storageTable, operation.Entity);
                case TableOperationType.Replace:
                    var retrieveResult = await _storageTable.ExecuteAsync(TableOperation.Retrieve(operation.Entity.PartitionKey, operation.Entity.RowKey));
                    return async () => await UndoReplaceOperation(_storageTable, retrieveResult.Result as DynamicTableEntity, operation.Entity);
                //case TableOperationType.Merge:
                //    break;
                //case TableOperationType.InsertOrReplace:
                //    break;
                //case TableOperationType.InsertOrMerge:
                //    break;
                //case TableOperationType.Retrieve:
                //    break;
                //case TableOperationType.RotateEncryptionKey:
                //    break;
                default:
                    throw new InvalidOperationException("The operation cannot be undone");
            }
        }

        private async Task UndoInsertOperationAsync(CloudTable table, ITableEntity entity)
        {
            var deleteOperation = TableOperation.Delete(entity);
            await table.ExecuteAsync(deleteOperation);
        }

        private async Task UndoDeleteOperation(CloudTable table, ITableEntity entity)
        {
            var entityToRestore = entity as BaseEntity;
            entityToRestore.IsDeleted = false;
            var insertOperation = TableOperation.Replace(entity);
            await table.ExecuteAsync(insertOperation);
        }

        private async Task UndoReplaceOperation(CloudTable table, ITableEntity originalEntity, ITableEntity newEntity)
        {
            if (originalEntity == null)
                return;
            if (!String.IsNullOrEmpty(newEntity.ETag))
                originalEntity.ETag = newEntity.ETag;
            var replaceOperation = TableOperation.Replace(originalEntity);
            await table.ExecuteAsync(replaceOperation);
        }

        public async Task<bool> Exists(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var entity = await _storageTable.ExecuteAsync(retrieveOperation);
            return entity.Result != null;
        }
    }
}
