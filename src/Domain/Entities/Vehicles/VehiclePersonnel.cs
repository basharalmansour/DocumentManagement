using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Domain.Entities.Vendors;

namespace CleanArchitecture.Domain.Entities.Vehicles;
public class VehiclePersonnel : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [ForeignKey(nameof(Vehicle))]
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }

    [ForeignKey(nameof(VendorPersonnel))]
    public int VendorPersonnelId { get; set; }
    public VendorPersonnel VendorPersonnel { get; set; }
}
