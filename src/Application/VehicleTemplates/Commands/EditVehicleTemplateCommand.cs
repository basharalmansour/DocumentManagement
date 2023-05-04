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

namespace CleanArchitecture.Application.VehicleTemplates.Commands;
public class EditVehicleTemplateCommand :CreateVehicleTemplateCommand , IRequest<bool>
{
    public int Id { get; set; }
}

public class EditVehicleTemplateCommandHandler : BaseCommandHandler, IRequestHandler<EditVehicleTemplateCommand, bool>
{

    public EditVehicleTemplateCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }

    public async Task<bool> Handle(EditVehicleTemplateCommand request, CancellationToken cancellationToken)
    {
        var editedVehicle = _applicationDbContext.VehicleTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (editedVehicle == null)
            throw new Exception("VehicleTemplate was NOT found");
        _mapper.Map(request, editedVehicle);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true; 
    }
}
