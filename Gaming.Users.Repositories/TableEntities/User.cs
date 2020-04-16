using Gaming.Client.Interfaces.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Gaming.Users.Repositories.TableEntities
{
    internal class User : TableEntity, IUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
