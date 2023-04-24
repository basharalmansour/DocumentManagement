using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class AddSiteDocuments : IRequest<bool>
{
    public Guid SiteId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddSiteDocumentsHandler : IRequestHandler<AddSiteDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public AddSiteDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(AddSiteDocuments request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateSite>(request);
        _applicationDbContext.DocumentTemplateSites.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
