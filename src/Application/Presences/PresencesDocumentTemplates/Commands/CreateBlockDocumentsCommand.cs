using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public  class CreateBlockDocumentsCommand : IRequest<bool>
{
    public Guid BlockId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddBlockDocumentsHandler : BaseCommandHandler, IRequestHandler<CreateBlockDocumentsCommand, bool>
{
    public AddBlockDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(CreateBlockDocumentsCommand request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateBlock>(request);
        _applicationDbContext.DocumentTemplateBlocks.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}