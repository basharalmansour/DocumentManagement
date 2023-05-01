using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class CreateSiteDocumentsCommand : IRequest<bool>
{
    public Guid SiteId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddSiteDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<CreateSiteDocumentsCommand, bool>
{
    public AddSiteDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(CreateSiteDocumentsCommand request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateSite>(request);
        _applicationDbContext.DocumentTemplateSites.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
