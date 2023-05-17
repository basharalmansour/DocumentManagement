using CleanArchitecture.Domain.Entities.DocumentTemplates;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class CategoryDocumentDto
{
    public int DocumentTemplateId { get; set; }
    public int ServiceCategoryId { get; set; }
    public bool IsRequired { get; set; }
}