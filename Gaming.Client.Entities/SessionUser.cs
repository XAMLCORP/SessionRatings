using Gaming.Client.Interfaces.Entities;
using System;

namespace Gaming.Client.Entities
{
    public class SessionUser : ISessionUser
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public Session Session { get; set; }
        public User User { get; set; }
        public Rating Rating { get; set; }
    }
}
