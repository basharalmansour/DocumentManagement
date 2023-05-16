using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Vehicles;
using CleanArchitecture.Domain.Entities.Venders;

namespace CleanArchitecture.Domain.Entities.Vendors;
public class Vendor : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    public List<VendorPersonnel> VendorPersonnels { get; set; }
    public List<Vehicle> Vehicles { get; set; }

    public override void DeleteByEdit()
    {
        if (VendorPersonnels != null)
            VendorPersonnels.ForEach(x => x.DeleteByEdit());
        if (Vehicles != null)
            Vehicles.ForEach(x => x.DeleteByEdit());
        base.DeleteByEdit();
    }
}
