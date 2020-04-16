using Gaming.Client.Entities;
using Gaming.Foundation.Configuration;
using Gaming.Foundation.DataAccess;
using Gaming.Users.Interfaces.Repositores;
using System;
using System.Threading.Tasks;

namespace Gaming.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = "UseDevelopmentStorage=true";
        private AzureStorageRepository<TableEntities.User> _repository;

        public UserRepository()
        {
            _repository = new AzureStorageRepository<TableEntities.User>(_connectionString);
            _connectionString = Configuration.Instance.GetUsersDatabaseConnection();
        }

        public async Task CreateTable()
        {
            await _repository.CreateTable();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return TableEntities.UserClientEntityConverter.ConvertTo(await _repository.Find("1", userId.ToString()));
        }

        internal async Task Save(User user)
        {
            var tableEntity = TableEntities.UserClientEntityConverter.ConvertFrom(user);
            await _repository.Save(tableEntity);
        }
    }
}
