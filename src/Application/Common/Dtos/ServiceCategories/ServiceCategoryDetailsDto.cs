using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.PresenceCategoryDtos;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class ServiceCategoryDetailsDto
{
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
    public int MinOrderDuration { get; set; }
    public TimeUnit MinOrderDurationUnit { get; set; }
    public int MaxOrderDuration { get; set; }
    public TimeUnit MaxOrderDurationUnit { get; set; }
    public int MaxPersonnelCount { get; set; }
    public bool IsParallelApprovement { get; set; }
    public List<VehicleCategoryDto> VehicleTemplates { get; set; }
    public List<CategoryDocumentDto> Documents { get; set; }
    public List<CategoryPersonnelDocumentDto> PersonnelDocuments { get; set; }
    public List<ServiceCategoryRole> ServiceCategoryRoles { get; set; }
    public List<ServiceCategoryAreaDto> ServiceCategoryAreas { get; set; }
    public List<ServiceCategoryBlockDto> ServiceCategoryBlocks { get; set; }
    public List<ServiceCategoryBrandDto> ServiceCategoryBrands { get; set; }
    public List<ServiceCategoryCompanyDto> ServiceCategoryCompanies { get; set; }
    public List<ServiceCategorySiteDto> ServiceCategorySites { get; set; }
    public List<ServiceCategoryUnitDto> ServiceCategoryUnits { get; set; }
    public List<ServiceCategoryZoneDto> ServiceCategoryZones { get; set; }
    public List<ServiceCategoryPresenceGroupDto> ServiceCategoryPresenceGroups { get; set; }
}
