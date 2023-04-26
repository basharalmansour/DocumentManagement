using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class AddPresenceGroupDocument : IRequest<bool>
{
    public int PresenceGroupId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddPresenceGroupDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<AddPresenceGroupDocument, bool>
{

    public AddPresenceGroupDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }
    public async Task<bool> Handle(AddPresenceGroupDocument request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplatePresenceGroup>(request);
        _applicationDbContext.DocumentTemplatePresenceGroups.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}