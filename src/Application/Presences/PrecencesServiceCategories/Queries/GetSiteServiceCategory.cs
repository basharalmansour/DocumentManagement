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
public class GetSiteServiceCategory : IRequest<List<BasicServiceCategoryDto>>
{
    public Guid SiteId { get; set; }
}
public class GetSiteServiceCategoryHandler : BaseCommandQueryHandler, IRequestHandler<GetSiteServiceCategory, List<BasicServiceCategoryDto>>
{
    public GetSiteServiceCategoryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetSiteServiceCategory request, CancellationToken cancellationToken)
    {
        var serviceCategories = await _applicationDbContext.ServiceCategorySites.Where(x => x.SiteId == request.SiteId).Select(x => x.ServiceCategory).ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;
    }
}