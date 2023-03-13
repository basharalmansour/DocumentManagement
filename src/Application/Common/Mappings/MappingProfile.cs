using System.Reflection;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.PresenceGroups.Commands;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Vehicles.Commands;
using CleanArchitecture.Domain.Entities.Definitions.Vehicles;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.UsersGroup.Commands;
using CleanArchitecture.Domain.Entities.UserGroups;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.DocumentsTemplate.Commands;
using CleanArchitecture.Domain.Entities.Documents;

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
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<CreateVehicleCommand, Vehicle>();
        CreateMap<EditVehicleCommand, Vehicle>();


        CreateMap<CreateUserGroupCommand, UserGroup>();
        CreateMap<int, UserGroupPersonnel>()
            .ForMember(to => to.Id, opt => opt.MapFrom(from => from));
        CreateMap<UserGroup, GetUserGroupDto>();
        CreateMap<EditUserGroupCommand, UserGroup>();
        CreateMap<CreateFormCommnad, Form>();
        CreateMap<AddQuestionRequest, Question>();
        CreateMap<EditFormCommand, Form>();
        CreateMap<Form, FormDto>();
        CreateMap<Question, QuestionDto>();
        CreateMap<DocumentTemplate, GetDocumentTemplateDto>();
        //CreateMap<CreateDocumentTemplateCommand, DocumentTemplate>();
        CreateMap<EditDocumentTemplateCommand, DocumentTemplate>();

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
