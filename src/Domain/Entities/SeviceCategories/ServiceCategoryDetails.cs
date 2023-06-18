using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories;
public class ServiceCategoryDetails
{
    [Key]
    [ForeignKey(nameof(ServiceCategory))]
    public int Id { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
    public int MinOrderDuration { get; set; }
    public TimeUnit MinOrderDurationUnit { get; set; }
    public int MaxOrderDuration { get; set; }
    public TimeUnit MaxOrderDurationUnit { get; set; }
    public int MaxPersonnelCount { get; set; }
    public bool IsParallelApprovement { get; set; }
    public List<ServiceCategoryArea> ServiceCategoryAreas { get; set; }
    public List<ServiceCategoryBlock> ServiceCategoryBlocks { get; set; }
    public List<ServiceCategoryBrand> ServiceCategoryBrands { get; set; }
    public List<ServiceCategoryCompany> ServiceCategoryCompanies { get; set; }
    public List<ServiceCategorySite> ServiceCategorySites { get; set; }
    public List<ServiceCategoryUnit> ServiceCategoryUnits { get; set; }
    public List<ServiceCategoryZone> ServiceCategoryZones { get; set; }
    public List<ServiceCategoryPresenceGroup> ServiceCategoryPresenceGroups { get; set; }
    public List<ServiceCategoryVehicleTemplate> VehicleTemplates { get; set; }
    public List<ServiceCategoryDocument> Documents { get; set; }
    public List<ServiceCategoryPersonnelDocument> PersonnelDocuments { get; set; }
    public List<ServiceCategoryRole> ServiceCategoryRoles { get; set; }
}
