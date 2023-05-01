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
public class GetAreaDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int AreaId { get; set; }
}
public class AreaDocumentsQueryHandler : BaseCommandQueryHandler, IRequestHandler<GetAreaDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    public AreaDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(GetAreaDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _applicationDbContext.DocumentTemplateAreas
            .Include(x => x.DocumentTemplate)
            .Where(x => x.AreaId == request.AreaId)
            .Select(x => x.DocumentTemplate)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}