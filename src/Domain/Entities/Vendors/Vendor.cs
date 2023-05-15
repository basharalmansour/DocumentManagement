using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Venders;

namespace CleanArchitecture.Domain.Entities.Vendors;
public class Vendor : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    public List<VendorPersonnel> VendorPersonnels { get; set; }
}
