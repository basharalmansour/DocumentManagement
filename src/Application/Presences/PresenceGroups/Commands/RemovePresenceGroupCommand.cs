using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class RemovePresenceGroupCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class RemovePresenceGroupCommandHandler : BaseCommandQueryHandler, IRequestHandler<RemovePresenceGroupCommand, bool>
{

    public RemovePresenceGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(RemovePresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var deletedPresenceGroup = _applicationDbContext.PresenceGroups.FirstOrDefault(x => x.Id == request.Id);
        deletedPresenceGroup.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}