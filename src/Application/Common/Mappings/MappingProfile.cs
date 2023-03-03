using System.Reflection;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.DocumentsTemplate.Commands;
using CleanArchitecture.Domain.Entities.Documents;

namespace CleanArchitecture.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        CreateMap<DocumentTemplate, GetDocumentTemplateDto>();
        //CreateMap<CreateDocumentTemplateCommand, DocumentTemplate>();
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
