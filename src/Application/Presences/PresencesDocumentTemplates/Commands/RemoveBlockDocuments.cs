using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveBlockDocuments : IRequest<bool>
{
    public Guid  BlockId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveBlockDocumentsHandler : IRequestHandler<RemoveBlockDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemoveBlockDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(RemoveBlockDocuments request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateBlocks.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.BlockId == request.BlockId);
        _applicationDbContext.DocumentTemplateBlocks.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}