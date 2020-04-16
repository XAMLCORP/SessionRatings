using System;
using System.Collections.Generic;
using System.Text;

namespace Gaming.Sessions.Entities
{
    public static class SessionClientEntityConverter
    {
        public static Gaming.Client.Entities.Session ConvertTo(Session serverEntity)
        {
            if (serverEntity == null)
                return null;

            var clientEntity = new Gaming.Client.Entities.Session()
            {
                Id = serverEntity.Id,
                Start = serverEntity.Start,
                End = serverEntity.End
            };
            return clientEntity;
        }

        public static Session ConvertFrom(Gaming.Client.Entities.Session clientEntity)
        {
            if (clientEntity == null)
                return null;

            var serverEntity = new Session()
            {
                PartitionKey = "1",
                RowKey = clientEntity.Id.ToString(),
                Id = clientEntity.Id,
                Start = clientEntity.Start,
                End = clientEntity.End
            };
            return serverEntity;
        }
    }
}
