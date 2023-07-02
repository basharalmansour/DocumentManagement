using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.VehicleTemplates.Queries;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.Vehicles;
using CleanArchitecture.Domain.Entities.Vendors;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries;
public class GetVehiclesQuery : TableRequestModel, IRequest<TableResponseModel<VehicleDto>>
{
    public int VendorId { get; set; }
    public int? VehicleTemplateId { get; set; }
    public string SearchText { get; set; }
}

public class GetVehiclesQueryHandler : BaseQueryHandler, IRequestHandler<GetVehiclesQuery, TableResponseModel<VehicleDto>>
{

    public GetVehiclesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }

    public async Task<TableResponseModel<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Vehicle>();
        predicate = predicate.And(x => !x.IsDeleted);
        if (!string.IsNullOrEmpty(request.SearchText))
            predicate = predicate.And(x => x.PlateNumber.ToLower().Contains(request.SearchText.ToLower()));
        if (request.VehicleTemplateId != null)
        {
            predicate = predicate.And(x => x.VehicleTemplateId == request.VehicleTemplateId);
        }

        var vehicles = _applicationDbContext.Vehicles
            .Where(predicate);
        var selectedVehicles = await vehicles
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var vehiclesDto = _mapper.Map<List<VehicleDto>>(selectedVehicles);
        return new TableResponseModel<VehicleDto>(vehiclesDto, request.PageNumber, request.PageSize, vehicles.Count());
    }
}
