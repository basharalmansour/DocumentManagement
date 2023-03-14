using CleanArchitecture.Domain.Entities.Documents;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class CategoryDocumentDto
{
    public int DocumentTemplateId { get; set; }
    public int ServiceCategoryId { get; set; }
}