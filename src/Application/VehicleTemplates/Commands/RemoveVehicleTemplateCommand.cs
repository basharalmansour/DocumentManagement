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
public class RemoveVehicleTemplateCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class RemoveVehicleTemplateCommandHandler : BaseCommandHandler, IRequestHandler<RemoveVehicleTemplateCommand, bool>
{

    public RemoveVehicleTemplateCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }

    public async Task<bool> Handle(RemoveVehicleTemplateCommand request, CancellationToken cancellationToken)
    {
        var deletedVehicle = _applicationDbContext.VehicleTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (deletedVehicle == null)
            throw new Exception("VehicleTemplate was NOT found");
        deletedVehicle.DeleteByUser();
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}