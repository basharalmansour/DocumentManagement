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
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Domain.Enums;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vendors.Queries;
public class GetVendorsQuery : TableRequestModel, IRequest<TableResponseModel<BasicVendorDto>>
{
    public string SearchText { get; set; }
    public RecordStatus Status { get; set; }
}
public class GetVendorsHandler : BaseQueryHandler, IRequestHandler<GetVendorsQuery, TableResponseModel<BasicVendorDto>>
{
    public GetVendorsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicVendorDto>> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Vendor>();
        predicate = predicate.And(x => x.Status == request.Status);
        if(!string.IsNullOrEmpty(request.SearchText))
            predicate = predicate.And(x => x.Name.ToLower().Contains(request.SearchText.ToLower()));
        var vendors = _applicationDbContext.Vendors
            .Include(x=>x.Categories).ThenInclude(x=>x.VendorCategory)
            .Where(predicate);
        var selectedVendors = await vendors
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicVendorDto>>(selectedVendors);
        return new TableResponseModel<BasicVendorDto>(result, request.PageNumber, request.PageSize, vendors.Count());
    }
}