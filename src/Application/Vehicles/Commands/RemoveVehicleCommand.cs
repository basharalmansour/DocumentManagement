using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Vehicles.Commands;
public class RemoveVehicleCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class RemoveVehicleCommandHandler : BaseCommandHandler, IRequestHandler<RemoveVehicleCommand, bool>
{

    public RemoveVehicleCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }

    public async Task<bool> Handle(RemoveVehicleCommand request, CancellationToken cancellationToken)
    {
        var deletedVehicle = _applicationDbContext.Vehicles.FirstOrDefault(x => x.Id == request.Id);
        if (deletedVehicle == null)
            throw new Exception("Vehicle was NOT found");
        deletedVehicle.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}