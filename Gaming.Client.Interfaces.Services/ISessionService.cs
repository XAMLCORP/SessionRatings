using Gaming.Client.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Client.Interfaces.Services
{
    public interface ISessionService
    {
        Task<List<Session>> GetAllSessions(Guid userId);
        Task<SessionUser> GetSessionUser(Guid sessionId, Guid userId);
        Task<bool> SessionUserExists(Guid sessionId, Guid userId);

        //Task<IEnumerable<Session>> GetLast15RatingsBySession();
    }
}
