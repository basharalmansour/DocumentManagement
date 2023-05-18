using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Orders;
public class Order : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }

    [ForeignKey(nameof(Vendor))]
    public int VendorId { get; set; }
    public Vendor Vendor { get; set; }

    [ForeignKey(nameof(ServiceCategory))]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }

    public int? IntegerPresenceId { get; set; }
    public Guid? GuidPresenceId { get; set; }
    public PresencesType PresencesType { get; set; }

    public List<OrderEquipment> Equipments { get; set; }
    public List<OrderServiceCategoryDocument> Documents { get; set; }
    public List<OrderPersonnel> Personnels { get; set; }
    public List<OrderVehicle> Vehicles { get; set; }
    DeleteByEdit
}
