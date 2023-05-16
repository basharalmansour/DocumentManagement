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
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.VehicleTemplates.Commands;
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
using CleanArchitecture.Application.Presences.PresenceGroups.Commands;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;
using CleanArchitecture.Domain.Entities.Definitions.Roles;
using CleanArchitecture.Domain.Entities.VehicleTemplates;
using CleanArchitecture.Domain.Entities.Vehicles;
using CleanArchitecture.Application.Common.Dtos.Vehicles;

namespace CleanArchitecture.Application.Common.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        ApplyMappingsOfServiceCategory();
        ApplyMappingsOfVehicleTemplate();
        ApplyMappingsOfVehicle();
        ApplyMappingsOfPresenceGroup();
        ApplyMappingsOfUserGroup();
        ApplyMappingsOfForm();
        ApplyMappingsOfDocumentTemplate();
        ApplyMappingsOfPresences();
        ApplyMappingsOfRoles();
    }

    private void ApplyMappingsOfVehicle()
    {
        CreateMap<Vehicle, VehicleDto>();
    }

    private void ApplyMappingsOfRoles()
    {
        CreateMap<Role, PersonnelRole>()
            .ForMember(des => des.Role, opt => opt.MapFrom(res => res));
    }

    private void ApplyMappingsOfPresences()
    {
        CreateMap<CreateAreaDocumentsCommand, DocumentTemplateArea>();
        CreateMap<CreateBlockDocumentsCommand, DocumentTemplateBlock>();
        CreateMap<CreateBrandDocumentsCommand, DocumentTemplateBrand>();
        CreateMap<CreateCompanyDocumentsCommand, DocumentTemplateCompany>();
        CreateMap<CreateSiteDocumentsCommand, DocumentTemplateSite>();
        CreateMap<CreateUnitDocumentsCommand, DocumentTemplateUnit>();
        CreateMap<CreateZoneDocumentsCommand, DocumentTemplateZone>();
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
        CreateMap<ServiceCategory, ServiceCategoryDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Description)));

        CreateMap<ServiceCategoryDetails, ServiceCategoryDetailsDto>();

        CreateMap<ServiceCategory, BasicServiceCategoryDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<ServiceCategoryArea, ServiceCategoryAreaDto>();
        CreateMap<ServiceCategoryBlock, ServiceCategoryBlockDto>();
        CreateMap<ServiceCategoryBrand, ServiceCategoryBrandDto>();
        CreateMap<ServiceCategoryCompany, ServiceCategoryCompanyDto>();
        CreateMap<ServiceCategorySite, ServiceCategorySiteDto>();
        CreateMap<ServiceCategoryUnit, ServiceCategoryUnitDto>();
        CreateMap<ServiceCategoryZone, ServiceCategoryZoneDto>();
        CreateMap<ServiceCategoryPresenceGroup, ServiceCategoryPresenceGroupDto>();


        CreateMap<CreateServiceCategoryCommand, ServiceCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Name)))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Description)));

        CreateMap<CreateServiceCategoryDetails, ServiceCategoryDetails>()
            .ForMember(des => des.ServiceCategoryAreas, opt => opt.MapFrom(src => 
                src.ServiceCategoryAreas.Select(x => new ServiceCategoryArea { AreaId = x })))
            .ForMember(des => des.ServiceCategoryBlocks, opt => opt.MapFrom(src => src.ServiceCategoryBlocks.Select(x => new ServiceCategoryBlock { BlockId = x })))
            .ForMember(des => des.ServiceCategoryBrands, opt => opt.MapFrom(src => src.ServiceCategoryBrands.Select(x => new ServiceCategoryBrand { BrandId = x })))
            .ForMember(des => des.ServiceCategoryCompanies, opt => opt.MapFrom(src => src.ServiceCategoryCompanies.Select(x => new ServiceCategoryCompany { CompanyId = x })))
            .ForMember(des => des.ServiceCategorySites, opt => opt.MapFrom(src => src.ServiceCategorySites.Select(x => new ServiceCategorySite { SiteId = x })))
            .ForMember(des => des.ServiceCategoryUnits, opt => opt.MapFrom(src => src.ServiceCategoryUnits.Select(x => new ServiceCategoryUnit { UnitId = x })))
            .ForMember(des => des.ServiceCategoryZones, opt => opt.MapFrom(src => src.ServiceCategoryZones.Select(x => new ServiceCategoryZone { ZoneId = x })))
            .ForMember(des => des.ServiceCategoryPresenceGroups, opt => opt.MapFrom(src => src.ServiceCategoryPresenceGroups.Select(x => new ServiceCategoryPresenceGroup { PresenceGroupId = x })));

        
        CreateMap<CreateCategoryRoleDto, ServiceCategoryRole>()
            .ForMember(des => des.ResponsibleDepartments, opt => opt.MapFrom(src => src.ResponsibleDepartments.Select(x => new ResponsibleDepartment { DepartmentId = x })))
            .ForMember(des => des.ResponsiblePersonnels, opt => opt.MapFrom(src => src.ResponsiblePersonnels.Select(x => new ResponsiblePersonnel { PersonnelId = x })))
            .ForMember(des => des.ResponsibleUserGroups, opt => opt.MapFrom(src => src.ResponsibleUserGroups.Select(x => new ResponsibleUserGroup { UserGroupId = x })));
        CreateMap<CreateServiceCategoryDocument, ServiceCategoryDocument>();
        CreateMap<CreateServiceCategoryPersonnelDocument, ServiceCategoryPersonnelDocument>();
        CreateMap<ServiceCategoryVehicleTemplate, VehicleCategoryDto>();
        CreateMap<ServiceCategoryVehicleTemplateDocument, CategoryVehicleDocumentsDto>();
        CreateMap<ServiceCategoryDocument, CategoryDocumentDto>();
        CreateMap<CreateVehicleTemplateCategoryDto, ServiceCategoryVehicleTemplate>();
        CreateMap<CreateCategoryVehicleTemplateDocuments, ServiceCategoryVehicleTemplateDocument>();
        CreateMap<ServiceCategoryPersonnelDocument, CategoryPersonnelDocumentDto>();
        CreateMap<ServiceCategoryRole, ServiceCategoryRoleDto>();
        CreateMap<ResponsibleDepartment, ResponsibleDepartmentDto>();
        CreateMap<ResponsiblePersonnel, ResponsiblePersonnelDto>();
        CreateMap<ResponsibleUserGroup, ResponsibleUserGroupDto>();
    }
    private void ApplyMappingsOfVehicleTemplate()
    {
        CreateMap<VehicleTemplate, VehicleTemplateDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<VehicleTemplateDriverDocument, VehicleTemplateDriverDocumentsDto>();
        CreateMap<VehicleTemplateDocument, VehicleTemplatesDocumentDto>();
        CreateMap<CreateVehicleTemplateCommand, VehicleTemplate>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Name)))
            .ForMember(des => des.VehicleTemplateDocuments, opt => opt.MapFrom(src => src.VehicleTemplateDocuments.Select(x => new VehicleTemplateDocument { DocumentTemplateId = x })))
            .ForMember(des => des.DriverDocuments, opt => opt.MapFrom(src => src.DriverDocuments.Select(x => new VehicleTemplateDriverDocument { DocumentTemplateId = x })));
        CreateMap<EditVehicleTemplateCommand, VehicleTemplate>();
    }
    private void ApplyMappingsOfPresenceGroup()
    {
        CreateMap<PresenceGroup, PresenceGroupDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<PresenceGroup, BasicPresenceGroupDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<CreatePresenceGroupCommand, PresenceGroup>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Name)))
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
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Name)))
            .ForMember(des => des.Personnels, opt => opt.MapFrom(src => src.PersonnelIds.Select(x => new UserGroupPersonnel { PersonnelId = x }).ToList()));
        CreateMap<UserGroup, GetUserGroupDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<UserGroupPersonnel, UserGroupPersonnelDto>();
        CreateMap<EditUserGroupCommand, UserGroup>();
    }
    private void ApplyMappingsOfForm()
    {
        CreateMap<Form, BasicFormDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<Form, FormDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<Question, QuestionDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<DateQuestionOptions, DateQuestionOptionsDto>();
        CreateMap<FileQuestionOptions, FileQuestionOptionsDto>();
        CreateMap<MultiChoicesOption, MultiChoicesOptionsDto>()
            .ForMember(dest => dest.Choice, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Choice)));

        CreateMap<CreateFormCommand, Form>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Name)));
        CreateMap<CreateQuestionRequest, Question>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Name)));
        CreateMap<CreateDateQuestionOptions, DateQuestionOptions>();
        CreateMap<CreateFileQuestionOptions, FileQuestionOptions>();
        CreateMap<CreateMultiChoicesOption, MultiChoicesOption>()
            .ForMember(dest => dest.Choice, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Choice)));

        CreateMap<EditFormCommand, Form>();
    }
    private void ApplyMappingsOfDocumentTemplate()
    {
        CreateMap<DocumentTemplate, GetDocumentTemplateDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)))
            .ForMember(dest => dest.DocumentTemplateFileTypes, opt => opt.MapFrom(src => src.DocumentTemplateFileTypes.Select(x => x.FileType).ToList()))
            .ForMember(dest => dest.Forms, opt => opt.MapFrom(src => src.Forms.Select(x => x.FormId).ToList()));
        CreateMap<DocumentTemplate, BasicDocumentTemplateDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.DeserializObject(src.Name)));
        CreateMap<CreateDocumentTemplateCommand, DocumentTemplate>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageJsonFormatter.SerializObject(src.Name)))
            .ForMember(dest => dest.Forms, opt => opt.MapFrom(src => src.Forms.Select(j => new DocumentTemplateForm() { FormId = j }).ToList()));
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
