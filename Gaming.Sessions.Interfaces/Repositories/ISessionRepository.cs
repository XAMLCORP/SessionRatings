using Gaming.Client.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Sessions.Repositories
{
    public interface ISessionRepository
    {
        Task CreateTable();
        Task<List<Session>> GetAllSessions();
    }
}
