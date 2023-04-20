using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Queries;
public class PresenceGroupByIdQuery : IRequest<PresenceGroupDto>
{
    public int Id { get; set; }
}
public class PresenceGroupByIdQueryHandler : IRequestHandler<PresenceGroupByIdQuery, PresenceGroupDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public PresenceGroupByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<PresenceGroupDto> Handle(PresenceGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var presenceGroup = await _applicationDbContext.PresenceGroups
            .Include(x => x.PresenceGroupAreas)
            .Include(x => x.PresenceGroupBlocks)
            .Include(x => x.PresenceGroupBrands)
            .Include(x => x.PresenceGroupCompanies)
            .Include(x => x.PresenceGroupSites)
            .Include(x => x.PresenceGroupUnits)
            .Include(x => x.PresenceGroupZones)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        var presenceGroupDto = _mapper.Map<PresenceGroupDto>(presenceGroup);
        return presenceGroupDto;
    }
}
