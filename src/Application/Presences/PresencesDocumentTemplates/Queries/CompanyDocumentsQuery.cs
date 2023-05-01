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
public class CompanyDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int CompanyId { get; set; }
}
public class CompanyDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<CompanyDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    public CompanyDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(CompanyDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _applicationDbContext.DocumentTemplateCompanies
            .Include(x => x.DocumentTemplate)
            .Where(x => x.CompanyId == request.CompanyId)
            .Select(x => x.DocumentTemplate)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}