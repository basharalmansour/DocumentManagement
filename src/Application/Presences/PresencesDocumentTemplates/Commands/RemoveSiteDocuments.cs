using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveSiteDocuments : IRequest<bool>
{
    public Guid SiteId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveSiteDocumentsHandler : IRequestHandler<RemoveSiteDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemoveSiteDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(RemoveSiteDocuments request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateSites.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.SiteId == request.SiteId);
        _applicationDbContext.DocumentTemplateSites.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}