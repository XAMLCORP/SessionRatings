using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Gaming.Foundation.DataAccess
{
    public class BaseEntity : TableEntity
    {
        public bool IsDeleted;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
    }
}