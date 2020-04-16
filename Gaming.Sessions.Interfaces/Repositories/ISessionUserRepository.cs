using Gaming.Client.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Sessions.Repositories
{
    public interface ISessionUserRepository
    {
        Task CreateTableAsync();
        Task<List<SessionUser>> GetSessionUsers(Guid sessionId);
        Task<SessionUser> GetSessionUser(Guid sessionId, Guid userId);
        Task<bool> SessionUserExists(Guid sessionId, Guid userId);
    }
}
