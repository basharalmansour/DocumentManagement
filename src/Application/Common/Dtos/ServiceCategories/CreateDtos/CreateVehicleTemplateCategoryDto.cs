namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;

public class CreateVehicleTemplateCategoryDto
{
    public int VehicleTemplateId { get; set; }
    public List<CreateCategoryVehicleTemplateDocuments> VehicleTemplateDocuments { get; set; }
}