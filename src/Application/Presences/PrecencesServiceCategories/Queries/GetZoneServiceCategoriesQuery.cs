using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PrecencesServiceCategories.Queries;
public class GetZoneServiceCategoriesQuery : TableRequestModel, IRequest<TableResponseModel<BasicServiceCategoryDto>>
{
    public Guid ZoneId { get; set; }
}
public class GetZoneServiceCategoriesHandler : BaseQueryHandler, IRequestHandler<GetZoneServiceCategoriesQuery, TableResponseModel<BasicServiceCategoryDto>>
{
    public GetZoneServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicServiceCategoryDto>> Handle(GetZoneServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var serviceCategories = _applicationDbContext.ServiceCategoryZones
            .Include(x => x.ServiceCategory)
            .Where(x => x.ZoneId == request.ZoneId);
        var selectedCategories = await serviceCategories
            .Select(x => x.ServiceCategory)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(selectedCategories);
        return new TableResponseModel<BasicServiceCategoryDto>(result, request.PageNumber, request.PageSize, serviceCategories.Count());
    }
}
