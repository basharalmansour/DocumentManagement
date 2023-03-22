namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class CreateVehicleCategoryDto
{
    public int VehicleId { get; set; }
    public List<CreateCategoryVehicleDocuments> VehicleDocuments { get; set; }
}