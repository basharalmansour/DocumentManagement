using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PrecencesServiceCategories.Queries;
public class GetSiteServiceCategoriesQuery : IRequest<List<BasicServiceCategoryDto>>
{
    public Guid SiteId { get; set; }
}
public class GetSiteServiceCategoriesHandler : BaseCommandQueryHandler, IRequestHandler<GetSiteServiceCategoriesQuery, List<BasicServiceCategoryDto>>
{
    public GetSiteServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetSiteServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var serviceCategories = await _applicationDbContext.ServiceCategorySites
            .Include(x => x.ServiceCategory)
            .Where(x => x.SiteId == request.SiteId)
            .Select(x => x.ServiceCategory)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;
    }
}