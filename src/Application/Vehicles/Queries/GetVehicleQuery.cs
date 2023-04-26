using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Customer.Commands;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.Vehicles.Queries;
public class GetVehicleQuery : IRequest<List<VehicleDto>>
{

}

public class GetVehicleQueryHandler : BaseCommandQueryHandler, IRequestHandler<GetVehicleQuery, List<VehicleDto>>
{

    public GetVehicleQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(mapper, applicationDbContext)
    {
    }

    public async Task<List<VehicleDto>> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _applicationDbContext.Vehicles.Where(x => x.IsDeleted == false).ToListAsync();
        var vehiclesDto = _mapper.Map<List<VehicleDto>>(vehicles);
        return vehiclesDto;
    }
}
