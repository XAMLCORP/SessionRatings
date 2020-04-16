using Gaming.Client.Entities;
using Gaming.Foundation.Async;
using Gaming.Foundation.DependencyInjection;
using Gaming.Users.Interfaces.Repositores;
using Gaming.Users.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Gaming.UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class UserServiceController : ControllerBase, IUserService
    {
        private readonly ILogger<UserServiceController> _logger;
        private readonly IUserRepository _repository;

        public UserServiceController(ILogger<UserServiceController> logger)
        {
            _logger = logger;
            _repository = ServiceLocator.Instance.GetService<IUserRepository>();
        }

        [HttpGet]
        [Route("[action]/{userid}")]
        public User GetUser(Guid userId)
        {
            return AsyncHelper.RunSync<User>(() => _repository.GetUserById(userId));
        }
    }
}