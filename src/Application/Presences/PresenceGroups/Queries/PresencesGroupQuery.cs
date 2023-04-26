using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Queries;

public class PresencesGroupQuery : IRequest<List<PresenceGroupDto>>
{
    public string SearchText { get; set; }
}
public class PresencesGroupQueryHandler : BaseCommandQueryHandler, IRequestHandler<PresencesGroupQuery, List<PresenceGroupDto>>
{

    public PresencesGroupQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(mapper, applicationDbContext)
    {

    }
    public async Task<List<PresenceGroupDto>> Handle(PresencesGroupQuery request, CancellationToken cancellationToken)
    {
        var presenceGroups = await _applicationDbContext.PresenceGroups
             .Include(x => x.PresenceGroupAreas)
             .Include(x => x.PresenceGroupBlocks)
             .Include(x => x.PresenceGroupBrands)
             .Include(x => x.PresenceGroupCompanies)
             .Include(x => x.PresenceGroupSites)
             .Include(x => x.PresenceGroupUnits)
             .Include(x => x.PresenceGroupZones)
             .Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText)).ToListAsync();
        var presenceGroupsDto = _mapper.Map<List<PresenceGroupDto>>(presenceGroups);
        return presenceGroupsDto;
    }
}
