using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
public class UnitDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int UnitId { get; set; }
}
public class UnitDocumentsQueryHandler : BaseCommandQueryHandler, IRequestHandler<UnitDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    public UnitDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(UnitDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _applicationDbContext.DocumentTemplateUnits
            .Include(x => x.DocumentTemplate)
            .Where(x => x.UnitId == request.UnitId)
            .Select(x => x.DocumentTemplate)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}

