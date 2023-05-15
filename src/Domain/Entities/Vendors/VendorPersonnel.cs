using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Vendors;

namespace CleanArchitecture.Domain.Entities.Venders;
public class VendorPersonnel : BaseEntity<int>, IEntity<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Telephone { get; set; }
    public string IdentityNo { get; set; }
    public string Email { get; set; }

    [ForeignKey(nameof(Vendor))]
    public int VenderId { get; set; }
    public Vendor Vendor { get; set; }
    
}
