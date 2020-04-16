using Gaming.Client.Interfaces.Entities;
using System;

namespace Gaming.Client.Entities
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
