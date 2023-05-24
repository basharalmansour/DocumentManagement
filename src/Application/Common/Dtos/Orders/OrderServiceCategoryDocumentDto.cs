using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderServiceCategoryDocumentDto
{
    public int ServiceCategoryDocumentId { get; set; }
    public int DocumentId { get; set; }
    public DocumentDto Document { get; set; }
}