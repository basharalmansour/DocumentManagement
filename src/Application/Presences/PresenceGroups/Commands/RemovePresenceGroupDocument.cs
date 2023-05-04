using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class RemovePresenceGroupDocument : IRequest<bool>
{
    public int PresenceGroupId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemovePresenceGroupDocumentsHandler : BaseCommandHandler, IRequestHandler<RemovePresenceGroupDocument, bool>
{

    public RemovePresenceGroupDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {

    }
    public async Task<bool> Handle(RemovePresenceGroupDocument request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplatePresenceGroups.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.PresenceGroupId == request.PresenceGroupId);
        if (document == null)
            throw new Exception("PresenceGroup or DocumentTemplate was NOT found");
        _applicationDbContext.DocumentTemplatePresenceGroups.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
