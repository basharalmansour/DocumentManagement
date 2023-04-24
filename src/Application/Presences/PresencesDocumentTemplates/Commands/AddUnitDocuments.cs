using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class AddUnitDocuments : IRequest<bool>
{
    public int UnitId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddUnitDocumentsHandler : IRequestHandler<AddUnitDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public AddUnitDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(AddUnitDocuments request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateUnit>(request);
        _applicationDbContext.DocumentTemplateUnits.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
