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
public class GetZoneDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public Guid ZoneId { get; set; }
}
public class ZoneDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<GetZoneDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    public ZoneDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(GetZoneDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _applicationDbContext.DocumentTemplateZones
            .Include(x => x.DocumentTemplate)
            .Where(x => x.ZoneId == request.ZoneId)
            .Select(x => x.DocumentTemplate)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}
