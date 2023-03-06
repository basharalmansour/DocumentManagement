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
        CreateMap<CreatePresenceGroupCommand, PresenceGroup>();
        CreateMap<PresenceGroupAreaDto, PresenceGroupArea>();
        CreateMap<PresenceGroupBlockDto, PresenceGroupBlock>();
        CreateMap<PresenceGroupBrandDto, PresenceGroupBrand>();
        CreateMap<PresenceGroupCompanyDto, PresenceGroupCompany>();
        CreateMap<PresenceGroupSiteDto, PresenceGroupSite>();
        CreateMap<PresenceGroupUnitDto, PresenceGroupUnit>();
        CreateMap<PresenceGroupZoneDto, PresenceGroupZone>(); 
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
