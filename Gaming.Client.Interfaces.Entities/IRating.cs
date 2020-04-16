using System;

namespace Gaming.Client.Interfaces.Entities
{
    public interface IRating
    {
        Guid SessionId { get; set; }
        Guid UserId { get; set; }
        RatingValue Value { get; set; }
        string Comment { get; set; }
    }
}
