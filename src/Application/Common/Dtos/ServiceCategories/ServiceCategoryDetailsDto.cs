using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.PresenceCategoryDtos;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class ServiceCategoryDetailsDto
{
    public int Id { get; set; }
    public string UniqueCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
    public int MaxPersonnelCount { get; set; }
    public int ParentServiceCategoryId { get; set; }
    public int ServiceCategoryApprovmentId { get; set; }
    public List<CategorySpecialRulesDto> SpecialRules { get; set; }
    public List<LightServiceCategoryDto> SubServiceCategories { get; set; }
    public List<VehicleCategoryDto> Vehicles { get; set; }
    public List<CategoryDocumentDto> Documents { get; set; }
    public List<CategoryPersonnelDocumentDto > PersonnelDocuments { get; set; }
    public ServiceCategoryRoleDto ServiceCategoryRoles { get; set; }
    public List<ServiceCategoryAreaDto> ServiceCategoryAreas { get; set; }
    public List<ServiceCategoryBlockDto> ServiceCategoryBlocks { get; set; }
    public List<ServiceCategoryBrandDto> ServiceCategoryBrands { get; set; }
    public List<ServiceCategoryCompanyDto> ServiceCategoryCompanies { get; set; }
    public List<ServiceCategorySiteDto> ServiceCategorySites { get; set; }
    public List<ServiceCategoryUnitDto> ServiceCategoryUnits { get; set; }
    public List<ServiceCategoryZoneDto> ServiceCategoryZones { get; set; }
}

