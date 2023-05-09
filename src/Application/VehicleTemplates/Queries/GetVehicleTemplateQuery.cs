using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Customer.Commands;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.VehicleTemplates.Queries;
public class GetVehicleTemplateQuery : TableRequestModel, IRequest<TableResponseModel<BasicVehicleTemplateDto>>
{

}

public class GetVehicleTemplateQueryHandler : BaseQueryHandler, IRequestHandler<GetVehicleTemplateQuery, TableResponseModel<BasicVehicleTemplateDto>>
{

    public GetVehicleTemplateQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }

    public async Task<TableResponseModel<BasicVehicleTemplateDto>> Handle(GetVehicleTemplateQuery request, CancellationToken cancellationToken)
    {
        var vehicles = _applicationDbContext.VehicleTemplates
            .Where(x => x.IsDeleted == false);
        var selectedVehicles = await vehicles
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var vehiclesDto = _mapper.Map<List<BasicVehicleTemplateDto>>(selectedVehicles);
        return new TableResponseModel<BasicVehicleTemplateDto>(vehiclesDto, request.PageNumber, request.PageSize, vehicles.Count());
    }
}
