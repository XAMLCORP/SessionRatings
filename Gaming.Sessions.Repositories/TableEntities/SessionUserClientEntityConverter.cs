namespace Gaming.Sessions.Repositories.TableEntities
{
    internal static class SessionUserClientEntityConverter
    {
        public static Gaming.Client.Entities.SessionUser ConvertTo(SessionUser serverEntity)
        {
            if (serverEntity == null)
                return null;

            var clientEntity = new Gaming.Client.Entities.SessionUser()
            {
                SessionId = serverEntity.SessionId,
                UserId = serverEntity.UserId
            };
            return clientEntity;
        }

        public static SessionUser ConvertFrom(Gaming.Client.Entities.SessionUser clientEntity)
        {
            if (clientEntity == null)
                return null;

            var serverEntity = new SessionUser()
            {
                PartitionKey = clientEntity.SessionId.ToString(),
                RowKey = clientEntity.UserId.ToString(),
                SessionId = clientEntity.SessionId,
                UserId = clientEntity.UserId
            };
            return serverEntity;
        }
    }
}
