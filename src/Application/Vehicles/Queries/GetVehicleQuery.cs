using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Customer.Commands;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.Vehicles.Queries;
public class GetVehicleQuery : IRequest<List<VehicleDto>>
{

}

public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, List<VehicleDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetVehicleQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<List<VehicleDto>> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _applicationDbContext.Vehicles.Where(x => x.IsDeleted == true).ToListAsync();
        var vehiclesDto = _mapper.Map<List<VehicleDto>>(vehicles);
        return vehiclesDto;
    }
}
