using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Definitions.Equipments;
using CleanArchitecture.Domain.Entities.Vendors;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderEquipment : LightBaseEntity<int> , IEntity<int>
{
    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey(nameof(Equipment))]
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }
}
