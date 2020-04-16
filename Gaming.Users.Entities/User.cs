using Gaming.Foundation.DataAccess;
using Gaming.Interfaces.Entities;
using System;

namespace Gaming.Users.Entities
{
    public class User : BaseEntity, IUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
