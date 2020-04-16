using Gaming.Client.Interfaces.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Gaming.Sessions.Repositories.TableEntities
{
    internal class Session : TableEntity, ISession
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
