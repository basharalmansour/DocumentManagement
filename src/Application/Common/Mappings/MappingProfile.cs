using System.Reflection;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.PresenceGroups.Commands;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;

namespace CleanArchitecture.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        CreateMap<PresenceGroup, PresenceGroupDto>();

        CreateMap<CreatePresenceGroupCommand, PresenceGroup>()
            .ForMember(des=>des.PresenceGroupAreas , opt=>opt.MapFrom(src=>src.PresenceGroupAreas.Select(x=>new PresenceGroupArea { AreaId=x}).ToList() ))
            .ForMember(des => des.PresenceGroupBlocks, opt => opt.MapFrom(src => src.PresenceGroupBlocks.Select(x => new PresenceGroupBlock { BlockId = x }).ToList()))
            .ForMember(des => des.PresenceGroupBrands, opt => opt.MapFrom(src => src.PresenceGroupBrands.Select(x => new PresenceGroupBrand { BrandId = x }).ToList()))
            .ForMember(des => des.PresenceGroupCompanies, opt => opt.MapFrom(src => src.presenceGroupCompanies.Select(x => new PresenceGroupCompany { CompanyId = x }).ToList()))
            .ForMember(des => des.PresenceGroupSites, opt => opt.MapFrom(src => src.PresenceGroupSites.Select(x => new PresenceGroupSite { SiteId = x }).ToList()))
            .ForMember(des => des.PresenceGroupUnits, opt => opt.MapFrom(src => src.PresenceGroupUnits.Select(x => new PresenceGroupUnit { UnitId = x }).ToList()))
            .ForMember(des => des.PresenceGroupZones, opt => opt.MapFrom(src => src.PresenceGroupZones.Select(x => new PresenceGroupZone { ZoneId = x }).ToList()));

        CreateMap<PresenceGroupArea, PresenceGroupAreaDto>();
        CreateMap<PresenceGroupBlock, PresenceGroupBlockDto>();
        CreateMap<PresenceGroupBrand, PresenceGroupBrandDto>();
        CreateMap<PresenceGroupCompany, PresenceGroupCompanyDto>();
        CreateMap<PresenceGroupSite, PresenceGroupSiteDto>();
        CreateMap<PresenceGroupUnit, PresenceGroupUnitDto>();
        CreateMap<PresenceGroupZone, PresenceGroupZoneDto>();
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
