using Gaming.Client.Entities;
using Gaming.Client.Interfaces.Services;
using Gaming.Foundation.WebClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.SessionService
{
    public class SessionService : ISessionService
    {
        private ApiClient _client = new ApiClient(new Uri(Settings.SessionServiceUrl));

        public async Task<List<Session>> GetAllSessions(Guid userId)
        {
            var requestUrl = _client.CreateRequestUri("GetAllSessions");
            return await _client.GetAsync<List<Session>>(requestUrl, userId);
        }

        public async Task<SessionUser> GetSessionUser(Guid sessionId, Guid userId)
        {
            var requestUrl = _client.CreateRequestUri("GetSessionUser/" + sessionId.ToString() + "/" + userId.ToString());
            return await _client.GetAsync<SessionUser>(requestUrl, userId);
        }

        public async Task<bool> SessionUserExists(Guid sessionId, Guid userId)
        {
            var requestUrl = _client.CreateRequestUri("SessionUserExists/" + sessionId.ToString() + "/" + userId.ToString());
            return await _client.GetAsync<bool>(requestUrl, userId);
        }
    }
}
