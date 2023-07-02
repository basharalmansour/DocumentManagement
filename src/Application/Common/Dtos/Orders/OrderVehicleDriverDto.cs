using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Vendors;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderVehicleDriverDto
{
    public int VendorPersonnelId { get; set; }
    public string PersonnelName { get; set; }
    public List<OrderVehicleDriverDocumentDto> Documents { get; set; }
}