using System;

namespace BaseFrameWork.Core.Entity
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity<T> where T : struct //denetlenebilir entityler (varlıklar)
    {
        public  T CreatedBy { get; set; }
        public  DateTime CreatedDate { get; set; }
        public  T? UpdatedBy { get; set; }
        public  DateTime? UpdateDate { get; set; }
    }
}
