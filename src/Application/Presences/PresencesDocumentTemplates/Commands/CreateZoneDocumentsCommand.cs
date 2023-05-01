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
public class CreateZoneDocumentsCommand : IRequest<bool>
{
    public Guid ZoneId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddZoneDocumentsHandler : BaseCommandHandler, IRequestHandler<CreateZoneDocumentsCommand, bool>
{
    public AddZoneDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(CreateZoneDocumentsCommand request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateZone>(request);
        _applicationDbContext.DocumentTemplateZones.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
