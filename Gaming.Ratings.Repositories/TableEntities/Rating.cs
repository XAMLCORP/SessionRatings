using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Gaming.Ratings.Repositories.TableEntities
{
    internal class Rating : TableEntity
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
    }
}
