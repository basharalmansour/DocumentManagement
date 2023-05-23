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
public class Order : BaseEntity<Guid>, ISoftDeletable, IAuditable, IEntity<Guid>
{
    public string UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public OrderStatus OrderStatus { get; set; }

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
    public OrderAdditionalParameters AdditionalParameters { get; set; }
    public override void DeleteByEdit()
    {
        if (Personnels != null)
            Personnels.ForEach(x => x.DeleteByEdit());

        if (Vehicles != null)
            Vehicles.ForEach(x => x.DeleteByEdit());
        base.DeleteByEdit();
    }
}
