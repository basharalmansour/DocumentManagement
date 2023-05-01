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
public class SiteDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public Guid SiteId { get; set; }
}
public class SiteDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<SiteDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    public SiteDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(SiteDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _applicationDbContext.DocumentTemplateSites
            .Include(x => x.DocumentTemplate)
            .Where(x => x.SiteId == request.SiteId)
            .Select(x => x.DocumentTemplate)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}