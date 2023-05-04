using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveUnitDocumentsCommand : IRequest<bool>
{
    public int UnitId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveUnitDocumentsHandler : BaseCommandHandler, IRequestHandler<RemoveUnitDocumentsCommand, bool>
{
    public RemoveUnitDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(RemoveUnitDocumentsCommand request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateUnits.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.UnitId == request.UnitId);
        if (document == null)
            throw new Exception("DocumentTemplate was NOT found");
        _applicationDbContext.DocumentTemplateUnits.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}