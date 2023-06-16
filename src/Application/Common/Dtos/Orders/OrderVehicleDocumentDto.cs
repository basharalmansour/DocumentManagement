using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderVehicleDocumentDto
{
    public int ServiceCategoryVehicleTemplateDocumentId { get; set; }
    public int DocumentId { get; set; }
    public DocumentDto Document { get; set; }
}