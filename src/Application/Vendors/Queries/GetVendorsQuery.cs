using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.Vendors;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vendors.Queries;
public class GetVendorsQuery : TableRequestModel, IRequest<TableResponseModel<BasicVendorDto>>
{
    public string SearchText { get; set; }
}
public class GetVendorsHandler : BaseQueryHandler, IRequestHandler<GetVendorsQuery, TableResponseModel<BasicVendorDto>>
{
    public GetVendorsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicVendorDto>> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
    {
        var vendors = _applicationDbContext.Vendors
            .Where(x => x.Name.Contains(request.SearchText));
        var selectedVendors = await vendors
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicVendorDto>>(selectedVendors);
        return new TableResponseModel<BasicVendorDto>(result, request.PageNumber, request.PageSize, vendors.Count());
    }
}