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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries;
public class GetVehicleTemplateByIdQuery : IRequest<VehicleTemplateDto>
{
    public int Id { get; set; }
}

public class GetVehicleTemplateByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetVehicleTemplateByIdQuery, VehicleTemplateDto>
{
    public GetVehicleTemplateByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }

    public async Task<VehicleTemplateDto> Handle(GetVehicleTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _applicationDbContext.VehicleTemplates
            .Include(x=>x.VehicleTemplateDocuments)
            .Include(x=>x.DriverDocuments)
            .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id==request.Id);
        if (vehicle == null)
            throw new Exception("VehicleTemplate was NOT found");
        var vehicleDto = _mapper.Map<VehicleTemplateDto>(vehicle);
        return vehicleDto;
    }
}