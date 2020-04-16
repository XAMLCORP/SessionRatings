using Gaming.Client.Entities;
using Gaming.Client.Interfaces.Services;
using Gaming.Foundation.WebClient;
using System;
using System.Threading.Tasks;

namespace Gaming.UserService
{
    public class UserService : IUserService
    {
        private ApiClient _client = new ApiClient(new Uri(Settings.UserServiceUrl));

        public async Task<User> GetUser(Guid userId)
        {
            var requestUrl = _client.CreateRequestUri("GetUser/" + userId.ToString());
            return await _client.GetAsync<User>(requestUrl, userId);  
            // this userId should be a security context user
            // there is no security context user in this example
        }
    }
}
