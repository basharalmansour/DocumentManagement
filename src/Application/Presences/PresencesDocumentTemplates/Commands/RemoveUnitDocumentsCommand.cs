using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveUnitDocumentsCommand : IRequest<bool>
{
    public int UnitId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveUnitDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<RemoveUnitDocumentsCommand, bool>
{
    public RemoveUnitDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(RemoveUnitDocumentsCommand request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateUnits.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.UnitId == request.UnitId);
        _applicationDbContext.DocumentTemplateUnits.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}