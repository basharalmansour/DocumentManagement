using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Customer.Commands;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.VehicleTemplates.Queries;
public class GetVehicleTemplateQuery : IRequest<List<BasicVehicleTemplateDto>>
{

}

public class GetVehicleTemplateQueryHandler : BaseQueryHandler, IRequestHandler<GetVehicleTemplateQuery, List<BasicVehicleTemplateDto>>
{

    public GetVehicleTemplateQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }

    public async Task<List<BasicVehicleTemplateDto>> Handle(GetVehicleTemplateQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _applicationDbContext.VehicleTemplates.Where(x => x.IsDeleted == false).ToListAsync();
        var vehiclesDto = _mapper.Map<List<BasicVehicleTemplateDto>>(vehicles);
        return vehiclesDto;
    }
}
