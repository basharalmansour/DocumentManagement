using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories;
public class ServiceCategory : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.MediumString)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
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
    public List<VehicleTemplateCategory> Vehicles { get; set; }
    public List<CategoryDocument> Documents { get; set; }
    public List<CategoryPersonnelDocument> PersonnelDocuments { get; set; }

    [ForeignKey("ParentServiceCategory") ] 
    public int? ParentServiceCategoryId { get; set; } 
    public ServiceCategory ParentServiceCategory { get; set; }
    public List<ServiceCategory> SubServiceCategories { get; set; }
    public List<ServiceCategoryRole> ServiceCategoryRoles { get; set; }
}
