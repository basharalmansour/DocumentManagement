using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PrecencesServiceCategories.Queries;
public class GetSiteServiceCategoriesQuery : TableRequestModel, IRequest<TableResponseModel<BasicServiceCategoryDto>>
{
    public Guid SiteId { get; set; }
}
public class GetSiteServiceCategoriesHandler : BaseQueryHandler, IRequestHandler<GetSiteServiceCategoriesQuery, TableResponseModel<BasicServiceCategoryDto>>
{
    public GetSiteServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicServiceCategoryDto>> Handle(GetSiteServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var serviceCategories = _applicationDbContext.ServiceCategorySites
            .Include(x => x.ServiceCategory)
            .Where(x => x.SiteId == request.SiteId);
        var selectedCategories = await serviceCategories
            .Select(x => x.ServiceCategory)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(selectedCategories);
        return new TableResponseModel<BasicServiceCategoryDto>(result, request.PageNumber, request.PageSize, serviceCategories.Count());
    }
}
