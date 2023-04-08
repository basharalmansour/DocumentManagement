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
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;
using CleanArchitecture.Application.Rules.Commands;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        ApplyMappingsOfServiceCategory();
        ApplyMappingsOfVehicle();
        ApplyMappingsOfPresenceGroup();
        ApplyMappingsOfUserGroup();
        ApplyMappingsOfForm();
        ApplyMappingsOfDocumentTemplate();
        CreateMap<CreatePersonnelRule, PersonnelRules>();
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
    private void ApplyMappingsOfServiceCategory()
    {
        CreateMap<ServiceCategory, GetServiceCategoryDto>();
        CreateMap<ServiceCategoryArea, ServiceCategoryAreaDto>();
        CreateMap<ServiceCategoryBlock, ServiceCategoryBlockDto>();
        CreateMap<ServiceCategoryBrand, ServiceCategoryBrandDto>();
        CreateMap<ServiceCategoryCompany, ServiceCategoryCompanyDto>();
        CreateMap<ServiceCategorySite, ServiceCategorySiteDto>();
        CreateMap<ServiceCategoryUnit, ServiceCategoryUnitDto>();
        CreateMap<ServiceCategoryZone, ServiceCategoryZoneDto>();
        CreateMap<CreateServiceCategoryCommand, ServiceCategory>()
            .ForMember(des => des.ServiceCategoryAreas, opt => opt.MapFrom(src => src.ServiceCategoryAreas.Select(x => new ServiceCategoryArea { AreaId = x })))
            .ForMember(des => des.ServiceCategoryBlocks, opt => opt.MapFrom(src => src.ServiceCategoryBlocks.Select(x => new ServiceCategoryBlock { BlockId = x })))
            .ForMember(des => des.ServiceCategoryBrands, opt => opt.MapFrom(src => src.ServiceCategoryBrands.Select(x => new ServiceCategoryBrand { BrandId = x })))
            .ForMember(des => des.ServiceCategoryCompanies, opt => opt.MapFrom(src => src.ServiceCategoryCompanies.Select(x => new ServiceCategoryCompany { CompanyId = x })))
            .ForMember(des => des.ServiceCategorySites, opt => opt.MapFrom(src => src.ServiceCategorySites.Select(x => new ServiceCategorySite { SiteId = x })))
            .ForMember(des => des.ServiceCategoryUnits, opt => opt.MapFrom(src => src.ServiceCategoryUnits.Select(x => new ServiceCategoryUnit { UnitId = x })))
            .ForMember(des => des.ServiceCategoryZones, opt => opt.MapFrom(src => src.ServiceCategoryZones.Select(x => new ServiceCategoryZone { ZoneId = x })))
            .ForMember(des => des.PersonnelDocuments, opt => opt.MapFrom(src => src.PersonnelDocuments.Select(x => new CategoryPersonnelDocument { DocumentTemplateId = x })))
            .ForMember(des => des.SpecialRules, opt => opt.MapFrom(src => src.SpecialRules.Select(x => new CategorySpecialRules { SpecialRuleId = x })))
            .ForMember(des => des.Documents, opt => opt.MapFrom(src => src.Documents.Select(x => new CategoryDocument { DocumentTemplateId = x })));

        CreateMap<CreateApprovementDto, ServiceCategoryApprovment>()
            .ForMember(des => des.ApproverDepartments, opt => opt.MapFrom(src => src.ApproverDepartments.Select(x => new ApproverDepartment { DepartmentId = x })))
            .ForMember(des => des.ApproverPersonnels, opt => opt.MapFrom(src => src.ApproverPersonnels.Select(x => new ApproverPersonnel { PersonnelId = x })))
            .ForMember(des => des.ApproverUserGroups, opt => opt.MapFrom(src => src.ApproverUserGroups.Select(x => new ApproverUserGroup { UserGroupId = x })));
        CreateMap<VehicleCategory, VehicleCategoryDto>();
        CreateMap<CategoryVehicleDocuments, CategoryVehicleDocumentsDto>();
        CreateMap<CategoryDocument, CategoryDocumentDto>();
        CreateMap<CreateVehicleCategoryDto, VehicleCategory>();
        CreateMap<CreateCategoryVehicleDocuments, CategoryVehicleDocuments>();
        CreateMap<CategoryVehicleDocuments, CategoryVehicleDocumentsDto>();
        CreateMap<CategoryDocumentDto, CategoryDocument>();
        CreateMap<CategoryPersonnelDocument, CategoryPersonnelDocumentDto>();
        CreateMap<CategorySpecialRulesDto, CategorySpecialRules>();
        CreateMap<ServiceCategoryApprovment, ServiceCategoryApprovmentDto>();
        CreateMap<ApproverDepartment, ApproverDepartmentDto>();
        CreateMap<ApproverPersonnel, ApproverPersonnelDto>();
        CreateMap<ApproverUserGroup, ApproverUserGroupDto>();
        CreateMap<DocumentCategoryDto, CategoryDocument>();
        CreateMap<CategorySpecialRules,CategorySpecialRulesDto>();
        CreateMap<ServiceCategoryArea, ServiceCategoryAreaDto>();
        CreateMap<ServiceCategoryBlock, ServiceCategoryBlockDto>();
        CreateMap<ServiceCategoryBrand , ServiceCategoryBrandDto>();
        CreateMap<ServiceCategoryCompany , ServiceCategoryCompanyDto>();
        CreateMap<ServiceCategorySite, ServiceCategorySiteDto>();
        CreateMap<ServiceCategoryUnit , ServiceCategoryUnitDto>();
        CreateMap<ServiceCategoryZone, ServiceCategoryZoneDto>();
    }
    private void ApplyMappingsOfVehicle()
    {
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<CreateVehicleCommand, Vehicle>();
        CreateMap<EditVehicleCommand, Vehicle>();
    }
    private void ApplyMappingsOfPresenceGroup()
    {
        CreateMap<PresenceGroup, PresenceGroupDto>();

        CreateMap<CreatePresenceGroupCommand, PresenceGroup>()
            .ForMember(des => des.PresenceGroupAreas, opt => opt.MapFrom(src => src.PresenceGroupAreas.Select(x => new PresenceGroupArea { AreaId = x }).ToList()))
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
    private void ApplyMappingsOfUserGroup()
    {
        CreateMap<CreateUserGroupCommand, UserGroup>()
        .ForMember(des => des.Personnels, opt => opt.MapFrom(src => src.PersonnelIds.Select(x => new UserGroupPersonnel { PersonnelId = x }).ToList()));

        CreateMap<UserGroup, GetUserGroupDto>();
        CreateMap<UserGroupPersonnel, UserGroupPersonnelDto>();
        CreateMap<EditUserGroupCommand, UserGroup>();
    }
    private void ApplyMappingsOfForm()
    {
        CreateMap<Form, FormDto>();
        CreateMap<Question, QuestionDto>();
        CreateMap<CreateFormCommand, Form>();
        CreateMap<AddQuestionRequest, Question>();
        CreateMap<EditFormCommand, Form>();
    }
    private void ApplyMappingsOfDocumentTemplate()
    {
        CreateMap<DocumentTemplate, GetDocumentTemplateDto>()
            .ForMember(dest => dest.DocumentTemplateFileTypes, opt => opt.MapFrom(src => src.DocumentTemplateFileTypes.Select(x => x.FileType).ToList()));
        CreateMap<DocumentTemplateFileType, DocumentTemplateFileTypeDto>();
        CreateMap<DocumentTemplate, BasicDocumentTemplateDto>();
        CreateMap<CreateDocumentTemplateCommand, DocumentTemplate>();
        CreateMap<EditDocumentTemplateCommand, DocumentTemplate>();
        CreateMap<DocumentFileType, DocumentTemplateFileType>()
            .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src));

    }
}


//public class CustomResolver : IValueResolver<DocumentFileType, DocumentTemplateFileType, DocumentFileType>
//{
//    public DocumentFileType Resolve(DocumentFileType source, DocumentTemplateFileType destination, DocumentFileType destMember, ResolutionContext context)
//    {
//        return destination.FileType;
//    }
//}
