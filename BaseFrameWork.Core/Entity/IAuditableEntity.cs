using System;

namespace BaseFrameWork.Core.Entity
{
    interface IAuditableEntity<T> where T: struct //T lerin boş bırakılabilir olması için
    {
         T CreatedBy { get; set; } //oluşturan bilgisi
        DateTime CreatedDate { get; set; } //oluşturulma tarihi

        T? UpdatedBy { get; set; } //güncelleyen //struct (Nullable<T> aynısı T?)
        DateTime? UpdateDate { get; set; } //güncelleme tarihi //struct
    }
}
