using Gaming.Client.Entities;
using System;

namespace Gaming.Users.Interfaces.Services
{
    public interface IUserService
    {
        User GetUser(Guid userId);
    }
}
