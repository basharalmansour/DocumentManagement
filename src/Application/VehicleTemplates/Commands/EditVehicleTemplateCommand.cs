using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.VehicleTemplates;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.VehicleTemplates.Commands;
public class EditVehicleTemplateCommand :CreateVehicleTemplateCommand , IRequest<int>
{
    public int Id { get; set; }
}

public class EditVehicleTemplateCommandHandler : BaseCommandHandler, IRequestHandler<EditVehicleTemplateCommand, int>
{

    public EditVehicleTemplateCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }

    public async Task<int> Handle(EditVehicleTemplateCommand request, CancellationToken cancellationToken)
    {
        var vehicleTemplate = _applicationDbContext.VehicleTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (vehicleTemplate == null)
            throw new Exception("Vehicle Template was NOT found");
        vehicleTemplate.DeleteByEdit();
        var newVehicleTemplate = _mapper.Map<VehicleTemplate>((CreateVehicleTemplateCommand)request);
        newVehicleTemplate.UniqueCode = vehicleTemplate.UniqueCode;
        _applicationDbContext.VehicleTemplates.Add(newVehicleTemplate);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newVehicleTemplate.Id;
    }
}
