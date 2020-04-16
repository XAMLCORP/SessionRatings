using Gaming.Foundation.DataAccess;
using Gaming.Interfaces.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gaming.Sessions.Entities
{
    public class SessionUser : BaseEntity, ISessionUser
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        // Ranking
        // Time
        // Score
        // etc.
    }
}
