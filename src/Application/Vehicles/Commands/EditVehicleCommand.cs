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
public class EditVehicleCommand :CreateVehicleCommand , IRequest<bool>
{
    public int Id { get; set; }
}

public class EditVehicleCommandHandler : BaseCommandHandler, IRequestHandler<EditVehicleCommand, bool>
{

    public EditVehicleCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }

    public async Task<bool> Handle(EditVehicleCommand request, CancellationToken cancellationToken)
    {
        var editedVehicle = _applicationDbContext.Vehicles.FirstOrDefault(x => x.Id == request.Id);
        if (editedVehicle == null)
            await NullHandleProcesser.ExeptionsThrow("Vehicle");
        _mapper.Map(request, editedVehicle);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true; 
    }
}
