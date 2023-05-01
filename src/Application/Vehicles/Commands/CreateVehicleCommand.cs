using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Vehicles.Queries;
using CleanArchitecture.Domain.Entities.Definitions.Vehicles;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Vehicles.Commands;
public class CreateVehicleCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public bool IsNeedDriver { get; set; }
    public List<int> VehicleDocuments { get; set; }
    public List<int> DriverDocuments { get; set; }
}

public class CreateVehicleCommandHandler : BaseCommandHandler, IRequestHandler<CreateVehicleCommand, int>
{
    public CreateVehicleCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }

    public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsNeedDriver)
            request.DriverDocuments = null;
        var vehicle = _mapper.Map<Vehicle>(request);
        _applicationDbContext.Vehicles.Add(vehicle);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return vehicle.Id; 
    }
}