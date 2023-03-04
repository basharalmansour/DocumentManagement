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

namespace CleanArchitecture.Application.PresenceGroups.Queries;

public class PresencesGroupQuery : IRequest<List<PresenceGroupDto>>
{
    public string SearchText { get; set; }
}
public class PresencesGroupQueryHandler : IRequestHandler<PresencesGroupQuery, List<PresenceGroupDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public PresencesGroupQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<PresenceGroupDto>> Handle(PresencesGroupQuery request, CancellationToken cancellationToken)
    {
       var presenceGroups=await _applicationDbContext.PresenceGroups.Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText)).ToListAsync();
        var presenceGroupsDto= _mapper.Map<List<PresenceGroupDto>>(presenceGroups);
        return presenceGroupsDto;
    }
}
