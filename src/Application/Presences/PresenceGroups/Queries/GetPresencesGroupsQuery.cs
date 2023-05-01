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

public class GetPresencesGroupsQuery : IRequest<List<BasicPresenceGroupDto>>
{
    public string SearchText { get; set; }
}
public class GetPresencesGroupsQueryHandler : BaseQueryHandler, IRequestHandler<GetPresencesGroupsQuery, List<BasicPresenceGroupDto>>
{

    public GetPresencesGroupsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {

    }
    public async Task<List<BasicPresenceGroupDto>> Handle(GetPresencesGroupsQuery request, CancellationToken cancellationToken)
    {
        var presenceGroups = await _applicationDbContext.PresenceGroups
             .Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText)).ToListAsync();
        var presenceGroupsDto = _mapper.Map<List<BasicPresenceGroupDto>>(presenceGroups);
        return presenceGroupsDto;
    }
}
