using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
public class ZoneDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public Guid ZoneId { get; set; }
}
public class ZoneDocumentsQueryHandler : IRequestHandler<ZoneDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public ZoneDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(ZoneDocumentsQuery request, CancellationToken cancellationToken)
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
