using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.PresenceGroups.Commands;
public class RemovePresenceGroupCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class RemovePresenceGroupCommandHandler : IRequestHandler<RemovePresenceGroupCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemovePresenceGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(RemovePresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var deletedPresenceGroup = _applicationDbContext.PresenceGroups.FirstOrDefault(x => x.Id == request.Id);
        deletedPresenceGroup.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}