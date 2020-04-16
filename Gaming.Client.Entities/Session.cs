using Gaming.Client.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace Gaming.Client.Entities
{
    public class Session : ISession
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<SessionUser> SessionUsers { get; set; }
    }
}
