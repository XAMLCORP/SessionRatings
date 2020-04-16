using Gaming.Client.Entities;
using System;
using System.Threading.Tasks;

namespace Gaming.Client.Interfaces.Services
{
    public interface IRatingService
    {
        Task<Rating> GetSessionRating(Guid sessionId, Guid userId);
        Task<Rating> GetSessionRatingByUser(Guid sessionId, Guid userId);
        Task SaveRating(Rating rating, Guid userId);
    }
}
