using Gaming.Client.Interfaces.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Gaming.Sessions.Repositories.TableEntities
{
    internal class SessionUser : TableEntity, ISessionUser
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        // Ranking
        // Time
        // Score
        // etc.
    }
}
