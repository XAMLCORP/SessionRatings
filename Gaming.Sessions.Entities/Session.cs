using Gaming.Foundation.DataAccess;
using Gaming.Foundation.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaming.Sessions.Entities
{
    public class Session : BaseEntity, ISession
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
