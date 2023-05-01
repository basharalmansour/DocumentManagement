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
public class CreateUnitDocumentsCommand : IRequest<bool>
{
    public int UnitId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddUnitDocumentsHandler : BaseCommandHandler, IRequestHandler<CreateUnitDocumentsCommand, bool>
{

    public AddUnitDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(CreateUnitDocumentsCommand request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateUnit>(request);
        _applicationDbContext.DocumentTemplateUnits.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
