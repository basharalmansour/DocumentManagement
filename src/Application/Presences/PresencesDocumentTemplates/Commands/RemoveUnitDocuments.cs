using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveUnitDocuments : IRequest<bool>
{
    public int UnitId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveUnitDocumentsHandler : IRequestHandler<RemoveUnitDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemoveUnitDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(RemoveUnitDocuments request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateUnits.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.UnitId == request.UnitId);
        _applicationDbContext.DocumentTemplateUnits.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}