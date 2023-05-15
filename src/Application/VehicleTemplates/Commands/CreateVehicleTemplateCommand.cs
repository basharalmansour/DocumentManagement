using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.VehicleTemplates.Queries;
using CleanArchitecture.Domain.Entities.VehicleTemplates;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.VehicleTemplates.Commands;
public class CreateVehicleTemplateCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public bool IsNeedDriver { get; set; }
    public List<int> VehicleTemplateDocuments { get; set; }
    public List<int> DriverDocuments { get; set; }
}

public class CreateVehicleCommandTemplateHandler : BaseCommandHandler, IRequestHandler<CreateVehicleTemplateCommand, int>
{
    public CreateVehicleCommandTemplateHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }

    public async Task<int> Handle(CreateVehicleTemplateCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsNeedDriver)
            request.DriverDocuments = null;
        var vehicleTemplate = _mapper.Map<VehicleTemplate>(request);
        _applicationDbContext.VehicleTemplates.Add(vehicleTemplate);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return vehicleTemplate.Id; 
    }
}