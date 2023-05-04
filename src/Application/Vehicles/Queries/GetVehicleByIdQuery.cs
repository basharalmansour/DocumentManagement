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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries;
public class GetVehicleByIdQuery : IRequest<VehicleDto>
{
    public int Id { get; set; }
}

public class GetVehicleByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetVehicleByIdQuery, VehicleDto>
{
    public GetVehicleByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }

    public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _applicationDbContext.Vehicles
            .Include(x=>x.VehicleDocuments)
            .Include(x=>x.DriverDocuments)
            .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id==request.Id);
        if (vehicle == null)
            await NullHandleProcesser.ExeptionsThrow("Vehicle");
        var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
        return vehicleDto;
    }
}