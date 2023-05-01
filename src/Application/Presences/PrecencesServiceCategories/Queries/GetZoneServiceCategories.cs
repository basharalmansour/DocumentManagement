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
public class GetZoneServiceCategories : IRequest<List<BasicServiceCategoryDto>>
{
    public Guid ZoneId { get; set; }
}
public class GetZoneServiceCategoriesHandler : BaseQueryHandler, IRequestHandler<GetZoneServiceCategories, List<BasicServiceCategoryDto>>
{
    public GetZoneServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetZoneServiceCategories request, CancellationToken cancellationToken)
    {
        var serviceCategories = await _applicationDbContext.ServiceCategoryZones
            .Include(x => x.ServiceCategory)
            .Where(x => x.ZoneId == request.ZoneId)
            .Select(x => x.ServiceCategory)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;
    }
}