using System;
using System.Collections.Generic;
using System.Text;

namespace Gaming.Users.Entities
{
    public static class UserClientEntityConverter
    {
        public static Gaming.Client.Entities.User ConvertTo(User serverEntity)
        {
            if (serverEntity == null)
                return null;

            var clientEntity = new Gaming.Client.Entities.User()
            {
                Id = serverEntity.Id,
                FirstName = serverEntity.FirstName,
                LastName = serverEntity.LastName
            };
            return clientEntity;
        }

        public static User ConvertFrom(Gaming.Client.Entities.User clientEntity)
        {
            if (clientEntity == null)
                return null;

            var serverEntity = new User()
            {
                PartitionKey = "1",
                RowKey = clientEntity.Id.ToString(),
                Id = clientEntity.Id,
                FirstName = clientEntity.FirstName,
                LastName = clientEntity.LastName
            };
            return serverEntity;
        }
    }
}
