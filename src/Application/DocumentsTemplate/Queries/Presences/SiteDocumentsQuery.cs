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

namespace CleanArchitecture.Application.DocumentsTemplate.Queries.Presences;
public class SiteDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public Guid SiteId { get; set; }
}
public class SiteDocumentsQueryHandler : IRequestHandler<SiteDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public SiteDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(SiteDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _applicationDbContext.DocumentTemplateSites.Where(x => x.SiteId == request.SiteId).Select(x => x.DocumentTemplate).ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}