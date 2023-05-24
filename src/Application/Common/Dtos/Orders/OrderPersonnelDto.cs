using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Venders;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderPersonnelDto
{
    public int VendorPersonnelId { get; set; }
    public string PersonnelName { get; set; }
    public List<OrderPersonnelDocumentDto> Documents { get; set; }
}