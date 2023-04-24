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
public class RemoveAreaDocuments : IRequest<bool>
{
    public int AreaId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveAreaDocumentsHandler : IRequestHandler<RemoveAreaDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemoveAreaDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(RemoveAreaDocuments request, CancellationToken cancellationToken)
    {
        var document= _applicationDbContext.DocumentTemplateAreas.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.AreaId == request.AreaId);
        _applicationDbContext.DocumentTemplateAreas.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
