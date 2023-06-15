using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Dtos.Vendors;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.VehicleTemplates.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vendors.Queries;
public class GetVendorByIdQuery : IRequest<GetVendorDto>
{
    public int Id { get; set; }
}

public class GetVendorByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetVendorByIdQuery, GetVendorDto>
{
    public GetVendorByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }

    public async Task<GetVendorDto> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
    {
        var vendor =await _applicationDbContext
            .Vendors
            .Include(x=>x.VendorsCategories)
            .ThenInclude(x=>x.VendorCategory)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (vendor == null)
            throw new Exception("Vendor was NOT found");
        var result = _mapper.Map<GetVendorDto>(vendor);
        return result;
    }
}