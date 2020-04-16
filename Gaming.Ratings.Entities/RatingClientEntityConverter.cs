using System;
using System.Collections.Generic;
using System.Text;

namespace Gaming.Ratings.Entities
{
    public static class RatingClientEntityConverter
    {
        public static Gaming.Client.Entities.Rating ConvertTo(Rating serverEntity)
        {
            if (serverEntity == null)
                return null;

            var clientEntity = new Gaming.Client.Entities.Rating()
            {
                UserId = serverEntity.UserId,
                SessionId = serverEntity.SessionId,
                Value = serverEntity.Value,
                Comment = serverEntity.Comment
            };
            return clientEntity;
        }

        public static Rating ConvertFrom(Gaming.Client.Entities.Rating clientEntity)
        {
            if (clientEntity == null)
                return null;

            var serverEntity = new Rating()
            {
                PartitionKey = clientEntity.SessionId.ToString(),
                RowKey = clientEntity.UserId.ToString(),
                UserId = clientEntity.UserId,
                SessionId = clientEntity.SessionId,
                Value = clientEntity.Value,
                Comment = clientEntity.Comment
            };
            return serverEntity;
        }
    }
}
