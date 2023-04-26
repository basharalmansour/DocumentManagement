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
public  class AddBlockDocuments : IRequest<bool>
{
    public Guid BlockId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddBlockDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<AddBlockDocuments, bool>
{
    public AddBlockDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(AddBlockDocuments request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateBlock>(request);
        _applicationDbContext.DocumentTemplateBlocks.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}