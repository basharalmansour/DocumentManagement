using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.PresenceGroups.Queries;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Pipelines.Sockets.Unofficial.Arenas;

namespace CleanArchitecture.Application.PresenceGroups.Commands;
public class CreatePresenceGroupCommand : IRequest<int>
{
    public string Name { get; set; }
    public PresencesType Type { get; set; }
    public List<int> GroupIds { get; set; }
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
        var presenceGroup=_mapper.Map<PresenceGroup>(request);
        _applicationDbContext.PresenceGroups.Add(presenceGroup);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return presenceGroup.Id;
    }
}

