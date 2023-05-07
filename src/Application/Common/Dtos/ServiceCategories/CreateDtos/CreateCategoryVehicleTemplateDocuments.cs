using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;

public class CreateCategoryVehicleTemplateDocuments
{
    public int DocumentTemplateId { get; set; }
    public bool IsRequired { get; set; }
    public VehicleDocumentType VehicleDocumentType { get; set; }
}