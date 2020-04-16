using Gaming.Client.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Ratings.Interfaces.Repositories
{
    public interface IRatingRepository
    {
        Task CreateTable();
        Task<Rating> GetSessionRatingByUser(Guid sessionId, Guid userId);
        Task<List<Rating>> GetLast15RatingsBySession(Guid sessionId, int ratingFilter);
        Task<List<Rating>> GetLast15RatingsOverall(int ratingFilter);
        Task Save(Rating rating);
    }
}
