using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Foundation.DataAccess
{
    public class AzureStorageRepository<T> where T : TableEntity, new()
    {
        private CloudStorageAccount _storageAccount;
        private CloudTableClient _tableClient;
        private CloudTable _storageTable;

        public AzureStorageRepository(string connectionString)
        {
            _storageAccount = CloudStorageAccount.Parse(connectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();
            var table = _tableClient.GetTableReference(typeof(T).Name);
            _storageTable = table;
        }

        public async Task CreateTable()
        {
            var table = _tableClient.GetTableReference(typeof(T).Name);
            await table.CreateIfNotExistsAsync();
        }

        public async Task<bool> Exists(string partitionKey, string rowKey)
        {
            var operation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var entity = await _storageTable.ExecuteAsync(operation);
            return entity.Result != null;
        }

        public async Task Delete(T entity)
        {
            var operation = TableOperation.Delete(entity);
            await _storageTable.ExecuteAsync(operation);
        }

        public async Task Save(T entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            await _storageTable.ExecuteAsync(operation);
        }

        public async Task<List<T>> FindAllByPartitionKey(string partitionKey)
        {
            var query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            TableContinuationToken tableContinuationToken = null;
            var result = await _storageTable.ExecuteQuerySegmentedAsync(query, tableContinuationToken);
            return result.Results;
        }

        public async Task<List<T>> FindAll()
        {
            var query = new TableQuery<T>();
            TableContinuationToken tableContinuationToken = null;
            var result = await _storageTable.ExecuteQuerySegmentedAsync(query, tableContinuationToken);
            return result.Results;
        }

        public async Task<T> Find(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var result = await _storageTable.ExecuteAsync(retrieveOperation);
            return result.Result as T;
        }
    }
}
