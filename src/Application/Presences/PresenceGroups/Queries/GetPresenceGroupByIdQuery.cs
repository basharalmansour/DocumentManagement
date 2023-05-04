using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Queries;
public class GetPresenceGroupByIdQuery : IRequest<PresenceGroupDto>
{
    public int Id { get; set; }
}
public class GetPresenceGroupByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetPresenceGroupByIdQuery, PresenceGroupDto>
{

    public GetPresenceGroupByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {

    }
    public async Task<PresenceGroupDto> Handle(GetPresenceGroupByIdQuery request, CancellationToken cancellationToken)
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
        if (presenceGroup == null)
            throw new Exception("PresenceGroup was NOT found");
        var presenceGroupDto = _mapper.Map<PresenceGroupDto>(presenceGroup);
        return presenceGroupDto;
    }
}
