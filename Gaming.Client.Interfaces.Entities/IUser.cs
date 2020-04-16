using System;

namespace Gaming.Client.Interfaces.Entities
{
    public interface IUser
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
