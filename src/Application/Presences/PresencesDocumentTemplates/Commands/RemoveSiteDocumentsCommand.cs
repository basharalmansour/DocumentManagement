using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveSiteDocumentsCommand : IRequest<bool>
{
    public Guid SiteId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveSiteDocumentsHandler : BaseCommandHandler, IRequestHandler<RemoveSiteDocumentsCommand, bool>
{
    public RemoveSiteDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(RemoveSiteDocumentsCommand request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateSites.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.SiteId == request.SiteId);
        _applicationDbContext.DocumentTemplateSites.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}