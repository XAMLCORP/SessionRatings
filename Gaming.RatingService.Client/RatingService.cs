using Gaming.Client.Entities;
using Gaming.Client.Interfaces.Services;
using Gaming.Foundation.WebClient;
using System;
using System.Threading.Tasks;

namespace Gaming.RatingService
{
    public class RatingService : IRatingService
    {
        private ApiClient _client = new ApiClient(new Uri(Settings.RatingServiceUrl));

        public async Task<Rating> GetSessionRating(Guid sessionId, Guid userId)
        {
            var requestUrl = _client.CreateRequestUri("GetSessionRating/" + sessionId.ToString());
            return await _client.GetAsync<Rating>(requestUrl, userId);
        }

        public async Task<Rating> GetSessionRatingByUser(Guid sessionId, Guid userId)
        {
            var requestUrl = _client.CreateRequestUri("GetSessionRatingByUser/" + sessionId.ToString() + "/" + userId.ToString());
            return await _client.GetAsync<Rating>(requestUrl, userId);
        }

        public async Task SaveRating(Rating rating, Guid userId)
        {
            var requestUrl = _client.CreateRequestUri("SaveRating");
            await _client.PostAsync<Rating>(requestUrl, rating, userId);
        }
    }
}
