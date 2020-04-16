using Gaming.Foundation.DataAccess;
using Gaming.Foundation.EntityInterfaces;
using Gaming.Interfaces.Entities;
using System;
using System.Runtime.Serialization;

namespace Gaming.Ratings.Entities
{
    public class Rating : BaseEntity, IRating
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public RatingValue Value { get; set; }
        public string Comment { get; set; }
    }
}
