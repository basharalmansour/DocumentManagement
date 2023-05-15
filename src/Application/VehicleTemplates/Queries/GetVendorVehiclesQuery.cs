using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.VehicleTemplates.Queries;
public class GetVendorVehiclesQuery : IRequest<VehicleDto>
{
    public int VendorId { get; set; }
    public int VehicleTemplateId { get; set; }
    public string SearchText { get; set; }
}

public class GetVendorVehiclesQueryHandler : BaseQueryHandler, IRequestHandler<GetVendorVehiclesQuery, VehicleDto>
{
    public GetVendorVehiclesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }

    public async Task<VehicleDto> Handle(GetVendorVehiclesQuery request, CancellationToken cancellationToken)
    {
    }
}
