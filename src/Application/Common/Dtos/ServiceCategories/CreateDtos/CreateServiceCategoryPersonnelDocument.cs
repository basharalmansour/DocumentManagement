using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;

public class CreateServiceCategoryPersonnelDocument
{
    public int DocumentTemplateId { get; set; }
    public bool IsRequired { get; set; }
}