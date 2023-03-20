using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class CreateCategoryVehicleDocuments
{
    public int DocumentTemplateId { get; set; }
    public VehicleDocumentType VehicleDocumentType { get; set; }
}