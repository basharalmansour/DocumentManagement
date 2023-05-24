using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderPersonnelDocumentDto
{
    public int ServiceCategoryPersonnelDocumentId { get; set; }
    public int DocumentId { get; set; }
    public DocumentDto Document { get; set; }
}