using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Vehicles.Queries;
using CleanArchitecture.Domain.Entities.Definitions.Vehicles;
using MediatR;

namespace CleanArchitecture.Application.Vehicles.Commands;
public class CreateVehicleCommand : IRequest<int>
{
    public string Name { get; set; }
}

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public CreateVehicleCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<Vehicle>(request);
        _applicationDbContext.Vehicles.Add(vehicle);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return vehicle.Id; 
    }
}