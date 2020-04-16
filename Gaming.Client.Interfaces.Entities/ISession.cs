using System;

namespace Gaming.Client.Interfaces.Entities
{
    public interface ISession
    {
        Guid Id { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }
}
