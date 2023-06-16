using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Vendors;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderDto : BasicOrderDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? IntegerPresenceId { get; set; }
    public Guid? GuidPresenceId { get; set; }
    public PresencesType PresencesType { get; set; }
    public string PresenceName { get; set; } 
    public BasicVendorDto Vendor { get; set; } 
    public BasicServiceCategoryDto ServiceCategory { get; set; }
    public List<int> Equipments { get; set; }
    public List<OrderServiceCategoryDocumentDto> Documents { get; set; }
    public List<OrderPersonnelDto> Personnels { get; set; }
    public List<OrderVehicleDto> Vehicles { get; set; }
}