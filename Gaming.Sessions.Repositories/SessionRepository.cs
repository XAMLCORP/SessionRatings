using Gaming.Client.Entities;
using Gaming.Client.Interfaces.Services;
using Gaming.Foundation.Async;
using Gaming.Foundation.Configuration;
using Gaming.Foundation.DataAccess;
using Gaming.Foundation.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Sessions.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly string _connectionString = "UseDevelopmentStorage=true";
        private AzureStorageRepository<TableEntities.Session> _repository;

        public SessionRepository()
        {
            _repository = new AzureStorageRepository<TableEntities.Session>(_connectionString);
            _connectionString = Configuration.Instance.GetSessionsDatabaseConnection();
        }

        public async Task CreateTable()
        {
            await _repository.CreateTable();
        }

        public async Task<List<Session>> GetAllSessions()
        {
            var sessions = new List<Session>();
            var serverSessions = await _repository.FindAll();

            Parallel.ForEach(serverSessions, (serverSession) =>
            {
                var sessionUserRepository = ServiceLocator.Instance.GetService<ISessionUserRepository>();
                var clientSession = TableEntities.SessionClientEntityConverter.ConvertTo(serverSession);
                clientSession.SessionUsers = AsyncHelper.RunSync<List<SessionUser>>(() => sessionUserRepository.GetSessionUsers(clientSession.Id));
                sessions.Add(clientSession);


                var getUsers = FillUsers(clientSession.SessionUsers);
                var getRatings = FillRatings(clientSession.SessionUsers);

                Task.WaitAll(getUsers, getRatings);
            });
            return sessions;
        }

        private async Task FillUsers(List<SessionUser> sessionUsers)
        {
            var userService = ServiceLocator.Instance.GetService<IUserService>();
            foreach (var sessionUser in sessionUsers)
                sessionUser.User = await userService.GetUser(sessionUser.UserId);
        }

        private async Task FillRatings(List<SessionUser> sessionUsers)
        {
            var ratingService = ServiceLocator.Instance.GetService<IRatingService>();
            foreach (var sessionUser in sessionUsers)
                sessionUser.Rating = await ratingService.GetSessionRatingByUser(sessionUser.SessionId, sessionUser.UserId);
        }

        internal async Task Save(Session session)
        {
            var tableEntity = TableEntities.SessionClientEntityConverter.ConvertFrom(session);
            await _repository.Save(tableEntity);
        }
    }
}
