using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Vehicles;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderVehicle : BaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey(nameof(Vehicle))]
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public List<OrderVehicleDriver> Drivers { get;set; }
    public List<OrderVehicleDocument> Documents { get;set; }

    public override void DeleteByEdit()
    {
        if (Drivers != null)
            Drivers.ForEach(x => x.DeleteByEdit());
        base.DeleteByEdit();
    }
}
