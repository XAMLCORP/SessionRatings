using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Foundation.Interfaces
{
    public interface IRepository<T> where T : TableEntity
    {
        void SetStorageAccount(string connectionString);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> SaveAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FindAsync(string partitionKey, string rowKey);
        Task<IEnumerable<T>> FindAllByPartitionKeyAsync(string partitionKey);
        Task<IEnumerable<T>> FindAllAsync();
        Task CreateTableAsync();
        IUnitOfWork Scope { get; set; }
        Task<bool> Exists(string partitionKey, string rowKey);
    }
}
