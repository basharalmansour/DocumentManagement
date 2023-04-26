using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class RemovePresenceGroupDocument : IRequest<bool>
{
    public int PresenceGroupId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemovePresenceGroupDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<RemovePresenceGroupDocument, bool>
{

    public RemovePresenceGroupDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }
    public async Task<bool> Handle(RemovePresenceGroupDocument request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplatePresenceGroups.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.PresenceGroupId == request.PresenceGroupId);
        _applicationDbContext.DocumentTemplatePresenceGroups.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
