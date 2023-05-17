using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Vehicles;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderVehicle : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey(nameof(Vehicle))]
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public List<OrderVehicleDriver> Drivers { get;set; }
    public List<OrderVehicleDocument> Documents { get;set; }
}
