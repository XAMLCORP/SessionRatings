using Gaming.Client.Entities;
using Gaming.Foundation.Configuration;
using Gaming.Foundation.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Sessions.Repositories
{
    public class SessionUserRepository : ISessionUserRepository
    {
        private readonly string _connectionString = "UseDevelopmentStorage=true";
        private AzureStorageRepository<TableEntities.SessionUser> _repository;

        public SessionUserRepository()
        {
            _repository = new AzureStorageRepository<TableEntities.SessionUser>(_connectionString);
            _connectionString = Configuration.Instance.GetSessionsDatabaseConnection();
        }

        public async Task CreateTableAsync()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<TableEntities.SessionUser>();
                repository.SetStorageAccount(_connectionString);
                await repository.CreateTableAsync();
            }
        }

        public async Task<List<SessionUser>> GetSessionUsers(Guid sessionId)
        {
            var sessionUsers = new List<SessionUser>();
            var serverSessionUsers = await _repository.FindAllByPartitionKey(sessionId.ToString());
            foreach (var serverSessionUser in serverSessionUsers)
                sessionUsers.Add(TableEntities.SessionUserClientEntityConverter.ConvertTo(serverSessionUser));
            return sessionUsers;
        }

        public async Task<SessionUser> GetSessionUser(Guid sessionId, Guid userId)
        {
            return TableEntities.SessionUserClientEntityConverter.ConvertTo(await _repository.Find(sessionId.ToString(), userId.ToString()));
        }

        public async Task<bool> SessionUserExists(Guid sessionId, Guid userId)
        {
            return ((await GetSessionUser(sessionId, userId)) != null);
        }

        internal async Task Save(SessionUser sessionUser)
        {
            var tableEntity = TableEntities.SessionUserClientEntityConverter.ConvertFrom(sessionUser);
            await _repository.Save(tableEntity);
        }
    }
}
