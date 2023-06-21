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
using CleanArchitecture.Domain.Entities.Vendors;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vendors.Queries;
public class GetVendorPersonnelsQuery : TableRequestModel, IRequest<TableResponseModel<GetVendorPersonnelDto>>
{
    public int VendorId { get; set; }
    public string SearchText { get; set; }
}
public class GetVendorPersonnelsHandler : BaseQueryHandler, IRequestHandler<GetVendorPersonnelsQuery, TableResponseModel<GetVendorPersonnelDto>>
{
    public GetVendorPersonnelsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<GetVendorPersonnelDto>> Handle(GetVendorPersonnelsQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<VendorPersonnel>();
        predicate = predicate.And(x => x.VendorId == request.VendorId);
        if (!string.IsNullOrEmpty(request.SearchText))
            predicate = predicate.And(x => x.Name.ToLower().Contains(request.SearchText));
        var personnels = _applicationDbContext.VendorPersonnels
            .Where(predicate);
        var selectedPersonnels = await personnels
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<GetVendorPersonnelDto>>(selectedPersonnels);
        return new TableResponseModel<GetVendorPersonnelDto>(result, request.PageNumber, request.PageSize, personnels.Count());
    }
}