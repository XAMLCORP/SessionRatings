using Gaming.Client.Entities;
using Gaming.Client.Interfaces.Services;
using Gaming.Foundation.Async;
using Gaming.Foundation.Configuration;
using Gaming.Foundation.DataAccess;
using Gaming.Foundation.DependencyInjection;
using Gaming.Ratings.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaming.Ratings.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        
        private readonly string _connectionString = "UseDevelopmentStorage=true";
        private AzureStorageRepository<TableEntities.Rating> _repository;

        public RatingRepository()
        {
            _repository = new AzureStorageRepository<TableEntities.Rating>(_connectionString);
            _connectionString = Configuration.Instance.GetSessionsDatabaseConnection();
        }

        public async Task CreateTable()
        {
            await _repository.CreateTable();
        }

        public async Task<List<Rating>> GetLast15RatingsBySession(Guid sessionId)
        {
            var ratings = new List<Rating>();
            var tableEntityRatings = (await _repository.FindAllByPartitionKey(sessionId.ToString())).OrderBy(rating => rating.Timestamp).Take(15);
            foreach (var rating in tableEntityRatings)
                ratings.Add(TableEntities.RatingClientEntityConverter.ConvertTo(rating));
            Parallel.ForEach(ratings, (rating) =>
            {
                var userService = ServiceLocator.Instance.GetService<IUserService>();
                rating.User = AsyncHelper.RunSync<User>(() => userService.GetUser(rating.UserId));
            });
            return ratings;
        }
                                             
        public async Task<List<Rating>> GetLast15RatingsOverall()
        {
            var ratings = new List<Rating>();
            var tableEntityRatings = (await _repository.FindAll()).OrderBy(rating => rating.Timestamp).Take(15);
            foreach (var rating in tableEntityRatings)
                ratings.Add(TableEntities.RatingClientEntityConverter.ConvertTo(rating));
            Parallel.ForEach(ratings, (rating) =>
            {
                var userService = ServiceLocator.Instance.GetService<IUserService>();
                rating.User = AsyncHelper.RunSync<User>(() => userService.GetUser(rating.UserId));
            });
            return ratings;
        }

        public async Task<Rating> GetSessionRatingByUser(Guid sessionId, Guid userId)
        {
            return TableEntities.RatingClientEntityConverter.ConvertTo(await _repository.Find(sessionId.ToString(), userId.ToString()));
        }

        public async Task Save(Rating rating)
        {
            var tableEntity = TableEntities.RatingClientEntityConverter.ConvertFrom(rating);
            await _repository.Save(tableEntity);
        }
    }
}
