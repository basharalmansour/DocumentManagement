﻿using System.Reflection;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Vehicles.Commands;
using CleanArchitecture.Domain.Entities.Definitions.Vehicles;

namespace CleanArchitecture.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<CreateVehicleCommand, Vehicle>();
        CreateMap<EditVehicleCommand, Vehicle>();

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
