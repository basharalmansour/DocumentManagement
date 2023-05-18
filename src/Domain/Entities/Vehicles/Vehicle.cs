using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.VehicleTemplates;
using CleanArchitecture.Domain.Entities.Vendors;

namespace CleanArchitecture.Domain.Entities.Vehicles;
public class Vehicle : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.ShortString)]
    public string PlateNumber { get; set; }
    [ForeignKey(nameof(Vendor))]
    public int VendorId { get; set; }
    public Vendor Vendor { get; set; }
    [ForeignKey(nameof(VehicleTemplate))]
    public int VehicleTemplateId { get; set; }
    public VehicleTemplate VehicleTemplate { get; set; }
    public List<VehiclePersonnel> Drivers { get; set; }

    DeleteByEdit
}
