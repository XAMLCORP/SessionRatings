using Gaming.Client.Entities;
using Gaming.Foundation.Async;
using Gaming.Foundation.DependencyInjection;
using Gaming.Foundation.MVC;
using Gaming.Sessions.Repositories;
using Gaming.Sessions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Gaming.SessionService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionServiceController : GamingControllerBase, ISessionService
    {
        private readonly ILogger<SessionServiceController> _logger;
        private readonly ISessionRepository _sessionRepository;
        private readonly ISessionUserRepository _sessionUserRepository;

        public SessionServiceController(ILogger<SessionServiceController> logger)
        {
            _logger = logger;
            _sessionRepository = ServiceLocator.Instance.GetService<ISessionRepository>();
            _sessionUserRepository = ServiceLocator.Instance.GetService<ISessionUserRepository>();
        }

        [HttpGet]
        [Route("[action]")]
        public List<Session> GetAllSessions()
        {
            return AsyncHelper.RunSync<List<Session>>(() => _sessionRepository.GetAllSessions());
        }

        [HttpGet]
        [Route("[action]/{sessionId}/{userId}")]
        public SessionUser GetSessionUser(Guid sessionId, Guid userId)
        {
            return AsyncHelper.RunSync<SessionUser>(() => _sessionUserRepository.GetSessionUser(sessionId, userId));
        }

        [HttpGet]
        [Route("[action]/{sessionId}/{userId}")]
        public bool SessionUserExists(Guid sessionId, Guid userId)
        {
            return AsyncHelper.RunSync<bool>(() => _sessionUserRepository.SessionUserExists(sessionId, userId));
        }
    }
}
