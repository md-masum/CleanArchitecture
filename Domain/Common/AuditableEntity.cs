using System;

namespace Domain.Common
{
    public class AuditableEntity
    {
        public bool IsSoftDelete { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}