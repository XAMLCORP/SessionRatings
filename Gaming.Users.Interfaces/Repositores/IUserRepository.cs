using Gaming.Client.Entities;
using System;
using System.Threading.Tasks;

namespace Gaming.Users.Interfaces.Repositores
{
    public interface IUserRepository
    {
        Task CreateTable();
        Task<User> GetUserById(Guid userId);
    }
}
