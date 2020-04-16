namespace Gaming.Ratings.Repositories.TableEntities
{
    internal static class RatingClientEntityConverter
    {
        public static Gaming.Client.Entities.Rating ConvertTo(Rating tableEntity)
        {
            if (tableEntity == null)
                return null;

            var clientEntity = new Gaming.Client.Entities.Rating()
            {
                UserId = tableEntity.UserId,
                SessionId = tableEntity.SessionId,
                Value = (Client.Interfaces.Entities.RatingValue)tableEntity.Value,
                Comment = tableEntity.Comment
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
                Value = (int)clientEntity.Value,
                Comment = clientEntity.Comment
            };
            return serverEntity;
        }
    }
}
