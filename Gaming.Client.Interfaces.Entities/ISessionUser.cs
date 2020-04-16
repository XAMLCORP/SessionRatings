using System;

namespace Gaming.Client.Interfaces.Entities
{
    public interface ISessionUser
    {
        Guid SessionId { get; set; }
        Guid UserId { get; set; }
    }
}
