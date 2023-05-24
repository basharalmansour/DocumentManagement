using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Venders;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Orders.CreateDtos;

public class CreateOrderPersonnelDto
{
    public int VendorPersonnelId { get; set; }
    public List<CreateOrderDocumentDto> Documents { get; set; }
}