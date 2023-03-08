using System.Reflection;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.PresenceCategoryDtos;
using CleanArchitecture.Application.ServiceCategories.Commands;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;

namespace CleanArchitecture.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        CreateMap<ServiceCategory, GetServiceCategoryDto>();
        CreateMap<CategorySpecialRules, CategorySpecialRulesDto>();

        CreateMap<ServiceCategoryArea , ServiceCategoryAreaDto>();
        CreateMap<ServiceCategoryBlock, ServiceCategoryBlockDto>();
        CreateMap<ServiceCategoryBrand, ServiceCategoryBrandDto>();
        CreateMap<ServiceCategoryCompany, ServiceCategoryCompanyDto>();
        CreateMap<ServiceCategorySite , ServiceCategorySiteDto>();
        CreateMap<ServiceCategoryUnit, ServiceCategoryUnitDto>();
        CreateMap<ServiceCategoryZone, ServiceCategoryZoneDto>();

        CreateMap<CreateServiceCategoryCommand, ServiceCategory>()
            .ForMember(des => des.ServiceCategoryAreas, opt => opt.MapFrom(src=>src.ServiceCategoryAreas.Select(x => new ServiceCategoryArea { AreaId = x })))
            .ForMember(des => des.ServiceCategoryBlocks, opt => opt.MapFrom(src => src.ServiceCategoryBlocks.Select(x => new ServiceCategoryBlock { BlockId = x })))
            .ForMember(des => des.ServiceCategoryBrands, opt => opt.MapFrom(src => src.ServiceCategoryBrands.Select(x => new ServiceCategoryBrand { BrandId = x })))
            .ForMember(des => des.ServiceCategoryCompanies, opt => opt.MapFrom(src => src.ServiceCategoryCompanies.Select(x => new ServiceCategoryCompany { CompanyId = x })))
            .ForMember(des => des.ServiceCategorySites, opt => opt.MapFrom(src => src.ServiceCategorySites.Select(x => new ServiceCategorySite { SiteId = x })))
            .ForMember(des => des.ServiceCategoryUnits , opt => opt.MapFrom(src => src.ServiceCategoryUnits.Select(x => new ServiceCategoryUnit { UnitId = x })))
            .ForMember(des => des.ServiceCategoryZones, opt => opt.MapFrom(src => src.ServiceCategoryZones.Select(x => new ServiceCategoryZone { ZoneId = x })));

        CreateMap<VehicleCategory, VehicleCategoryDto>();
        CreateMap<CategoryVehicleDocuments, CategoryVehicleDocumentsDto>();
        CreateMap<CategoryDocument, CategoryDocumentDto>();

        CreateMap<VehicleCategoryDto,VehicleCategory >();
        CreateMap<CategoryVehicleDocumentsDto,CategoryVehicleDocuments >();
        CreateMap<CategoryDocumentDto,CategoryDocument >();

        CreateMap<CategorySpecialRulesDto,CategorySpecialRules >();

        CreateMap<DocumentCategoryDto, CategoryDocument>();
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping")
                ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

            methodInfo?.Invoke(instance, new object[] { this });

        }
    }
}
