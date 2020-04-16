using Gaming.Client.Entities;
using System;
using System.Threading.Tasks;

namespace Gaming.Client.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUser(Guid userId);
    }
}
