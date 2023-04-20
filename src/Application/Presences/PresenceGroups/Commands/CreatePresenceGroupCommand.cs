using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Pipelines.Sockets.Unofficial.Arenas;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class CreatePresenceGroupCommand : IRequest<int>
{
    public string Name { get; set; }
    public List<int> PresenceGroupAreas { get; set; }
    public List<Guid> PresenceGroupBlocks { get; set; }
    public List<int> presenceGroupCompanies { get; set; }
    public List<int> PresenceGroupBrands { get; set; }
    public List<Guid> PresenceGroupSites { get; set; }
    public List<int> PresenceGroupUnits { get; set; }
    public List<Guid> PresenceGroupZones { get; set; }
}
public class CreatePresenceGroupCommandHandler : IRequestHandler<CreatePresenceGroupCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public CreatePresenceGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreatePresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var presenceGroup = _mapper.Map<PresenceGroup>(request);
        presenceGroup.UniqueCode = UniqueCode.CreateUniqueCode(8, false,"P");
        _applicationDbContext.PresenceGroups.Add(presenceGroup);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return presenceGroup.Id;
    }
}