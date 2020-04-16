using Gaming.Client.Entities;
using System;

namespace Gaming.Ratings.Interfaces.Services
{
    public interface IRatingService
    {
        Rating GetSessionRating(Guid sessionId);
        void SaveRating(Rating rating);
    }
}
