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
public class RemoveAreaDocumentsCommand : IRequest<bool>
{
    public int AreaId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveAreaDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<RemoveAreaDocumentsCommand, bool>
{

    public RemoveAreaDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }
    public async Task<bool> Handle(RemoveAreaDocumentsCommand request, CancellationToken cancellationToken)
    {
        var document= _applicationDbContext.DocumentTemplateAreas.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.AreaId == request.AreaId);
        _applicationDbContext.DocumentTemplateAreas.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
