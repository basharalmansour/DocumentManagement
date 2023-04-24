using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class AddPresenceGroupDocuments : IRequest<bool>
{
    public int PresenceGroupId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddPresenceGroupDocumentsHandler : IRequestHandler<AddPresenceGroupDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public AddPresenceGroupDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(AddPresenceGroupDocuments request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplatePresenceGroup>(request);
        _applicationDbContext.DocumentTemplatePresenceGroups.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}