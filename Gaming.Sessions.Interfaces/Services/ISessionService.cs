using Gaming.Client.Entities;
using System;
using System.Collections.Generic;

namespace Gaming.Sessions.Services
{
    public interface ISessionService
    {
        List<Session> GetAllSessions();

        SessionUser GetSessionUser(Guid sessionId, Guid userId);

    }
}
