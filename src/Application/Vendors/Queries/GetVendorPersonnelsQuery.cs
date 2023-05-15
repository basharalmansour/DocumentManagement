using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.VendorPersonnels;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vendors.Queries;
public class GetVendorPersonnelsQuery : TableRequestModel, IRequest<TableResponseModel<GetVendorPersonnelDto>>
{
    public int VenderId { get; set; }
}
public class GetVenderPersonnelsHandler : BaseQueryHandler, IRequestHandler<GetVendorPersonnelsQuery, TableResponseModel<GetVendorPersonnelDto>>
{
    public GetVenderPersonnelsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<GetVendorPersonnelDto>> Handle(GetVendorPersonnelsQuery request, CancellationToken cancellationToken)
    {
        var personnels = _applicationDbContext.VenderPersonnels
            .Where(x => x.VenderId == request.VenderId);
        var selectedPersonnels = await personnels
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<GetVendorPersonnelDto>>(selectedPersonnels);
        return new TableResponseModel<GetVendorPersonnelDto>(result, request.PageNumber, request.PageSize, personnels.Count());
    }
}