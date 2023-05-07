using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;

public class CreateServiceCategoryDetailsDto
{
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
    public int MinOrderDuration { get; set; }
    public TimeUnit MinOrderDurationUnit { get; set; }
    public int MaxOrderDuration { get; set; }
    public TimeUnit MaxOrderDurationUnit { get; set; }
    public int MaxPersonnelCount { get; set; }
    public List<int> PersonnelDocuments { get; set; }
    public bool IsPersonnelDocumentRequired { get; set; }
    public int? ParentServiceCategoryId { get; set; }
    public bool IsParallelApprovement { get; set; }
    public CreateCategoryRoleDto ServiceCategoryRoles { get; set; }
    public List<int> Documents { get; set; }
    public bool IsDocumentsRequired { get; set; }
    public List<CreateVehicleTemplateCategoryDto> VehicleTemplates { get; set; }
    public List<int> ServiceCategoryAreas { get; set; }
    public List<Guid> ServiceCategoryBlocks { get; set; }
    public List<int> ServiceCategoryBrands { get; set; }
    public List<int> ServiceCategoryCompanies { get; set; }
    public List<Guid> ServiceCategorySites { get; set; }
    public List<int> ServiceCategoryUnits { get; set; }
    public List<Guid> ServiceCategoryZones { get; set; }
    public List<int> ServiceCategoryPresenceGroups { get; set; }

}