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
public class GetZoneServiceCategory : IRequest<List<BasicServiceCategoryDto>>
{
    public Guid ZoneId { get; set; }
}
public class GetZoneServiceCategoryHandler : BaseCommandQueryHandler, IRequestHandler<GetZoneServiceCategory, List<BasicServiceCategoryDto>>
{
    public GetZoneServiceCategoryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetZoneServiceCategory request, CancellationToken cancellationToken)
    {
        var serviceCategories = await _applicationDbContext.ServiceCategoryZones.Where(x => x.ZoneId == request.ZoneId).Select(x => x.ServiceCategory).ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;
    }
}