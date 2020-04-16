using Gaming.Client.Entities;
using Gaming.Client.Interfaces.Entities;
using Gaming.Client.Interfaces.Services;
using Gaming.Foundation.Async;
using Gaming.Foundation.DependencyInjection;
using Gaming.Foundation.MVC;
using Gaming.Ratings.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Gaming.RatingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingServiceController : GamingControllerBase //, IRatingService
    {
        private readonly ILogger<RatingServiceController> _logger;
        private readonly IRatingRepository _repository;

        public RatingServiceController(ILogger<RatingServiceController> logger)
        {
            _logger = logger;
            _repository = ServiceLocator.Instance.GetService<IRatingRepository>();
        }

        [HttpGet]
        [Route("[action]/{sessionId}")]
        public Rating GetSessionRating(Guid sessionId)
        {
            return AsyncHelper.RunSync<Rating>(() => _repository.GetSessionRatingByUser(sessionId, UserId));
        }

        [HttpGet]
        [Route("[action]/{sessionId}/{userId}")]
        public Rating GetSessionRatingByUser(Guid sessionId, Guid userId)
        {
            // If the Ubi-UserId is supposed to be a security token, 
            // you would check for access before allowing this lookup
            return AsyncHelper.RunSync<Rating>(() => _repository.GetSessionRatingByUser(sessionId, userId));
        }

        [HttpPost]
        [Route("[action]/{sessionId}")]
        public IActionResult SaveRating(Guid sessionId, Rating rating)
        {
            //if (rating.UserId != UserId || sessionId != rating.SessionId)
            //    return StatusCode(StatusCodes.Status401Unauthorized);
            rating.UserId = UserId;
            rating.SessionId = sessionId;
            if (!ValidateRating(rating))
                return StatusCode(StatusCodes.Status400BadRequest);
            AsyncHelper.RunSync(() => _repository.Save(rating));
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("[action]/{sessionId}")]
        public List<Rating> GetLast15RatingsBySession(Guid sessionId, int ratingFilter = 0)
        {
            return AsyncHelper.RunSync<List<Rating>>(() => _repository.GetLast15RatingsBySession(sessionId, ratingFilter));
        }

        [HttpGet]
        [Route("[action]")]
        public List<Rating> GetLast15RatingsOverall(int ratingFilter = 0)
        {
            return AsyncHelper.RunSync<List<Rating>>(() => _repository.GetLast15RatingsOverall(ratingFilter));
        }

        // This should be done on the entity using a validation library and decorated with validation attributes
        // No time to implement proper entity validation
        private bool ValidateRating(Rating rating)
        {
            if (rating.Value > RatingValue.Five || rating.Value < RatingValue.NA)
                return false;
            var client = ServiceLocator.Instance.GetService<ISessionService>();

            var canUserRateSession = AsyncHelper.RunSync<bool>(() => client.SessionUserExists(rating.SessionId, rating.UserId));

            return canUserRateSession;
        }
    }
}
