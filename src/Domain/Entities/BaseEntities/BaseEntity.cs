using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.BaseEntities;
public class BaseEntity<T> : LightBaseEntity<T> where T : IEquatable<T>
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DeletionSource? DeletionSource { get; set; }

    [StringLength(StringLengths.GuidLengthString)]
    public string DeletedBy { get; set; }

    [StringLength(StringLengths.GuidLengthString)]
    public string CreatedBy { get; set; }

    [StringLength(StringLengths.GuidLengthString)]
    public string ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    [StringLength(StringLengths.ShortString)]
    public string UniqueCode { get; set; } 

    public void DeleteByUser()
    {
        DeletionSource = Enums.DeletionSource.DeletedByUser;
        SetDeleteSettings();
    }

    public virtual void DeleteByEdit()
    {
        DeletionSource = Enums.DeletionSource.DeletedByEdit;
        SetDeleteSettings();
    }

    private void SetDeleteSettings()
    {
        DeletedDate = DateTime.Now;
        IsDeleted = true;
    }
}
