using CleanArchitecture.Domain.Entities.SeviceCategories;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;

public class CreateServiceCategoryDocument
{
    public int DocumentTemplateId { get; set; }
    public bool IsRequired { get; set; }
}