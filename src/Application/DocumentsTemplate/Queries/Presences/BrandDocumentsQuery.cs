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
public class BrandDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int BrandId { get; set; }
}
public class BrandDocumentsQueryHandler : IRequestHandler<BrandDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public BrandDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(BrandDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _applicationDbContext.DocumentTemplateBrands.Where(x => x.BrandId == request.BrandId).Select(x => x.DocumentTemplate).ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}
