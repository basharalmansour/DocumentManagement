using System.Reflection;
using AutoMapper;
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
        CreateMap<DocumentTemplateFileType, DocumentTemplateFileTypeDto>();
        CreateMap<CreateDocumentTemplateCommand, DocumentTemplate>();
        CreateMap<EditDocumentTemplateCommand, DocumentTemplate>();

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
