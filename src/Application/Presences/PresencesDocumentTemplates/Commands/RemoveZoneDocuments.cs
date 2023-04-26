using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public  class RemoveZoneDocuments : IRequest<bool>
{
    public Guid ZoneId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveZoneDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<RemoveZoneDocuments, bool>
{

    public RemoveZoneDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(RemoveZoneDocuments request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateZones.FirstOrDefault(x => x.DocumentId == request.DocumentTemplateId && x.ZoneId == request.ZoneId);
        _applicationDbContext.DocumentTemplateZones.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
