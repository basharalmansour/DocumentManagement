using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Vehicles;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderVehicleDto
{
    public int VehicleId { get; set; }
    public VehicleDto Vehicle { get; set; }
    public List<OrderVehicleDriverDto> Drivers { get; set; }
    public List<OrderVehicleDocumentDto> Documents { get; set; }
}