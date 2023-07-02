using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class RemovePresenceGroupCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class RemovePresenceGroupCommandHandler : BaseCommandHandler, IRequestHandler<RemovePresenceGroupCommand, bool>
{

    public RemovePresenceGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<bool> Handle(RemovePresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var deletedPresenceGroup = _applicationDbContext.PresenceGroups.FirstOrDefault(x => x.Id == request.Id);
        if (deletedPresenceGroup == null)
            throw new Exception("PresenceGroup was NOT found");
        deletedPresenceGroup.DeleteByUser();
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}