using Gaming.Client.Interfaces.Entities;
using System;

namespace Gaming.Client.Entities
{
    public class Rating : IRating
    {
        public Guid SessionId { get; set; }

        public Guid UserId { get; set; }

        public RatingValue Value { get; set; }

        public string Comment { get; set; }

        public User User { get; set; }
    }
}
