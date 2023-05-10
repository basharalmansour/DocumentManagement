using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
public class GetCompanyDocumentsQuery : TableRequestModel, IRequest<TableResponseModel<BasicDocumentTemplateDto>>
{
    public int CompanyId { get; set; }
}
public class CompanyDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<GetCompanyDocumentsQuery, TableResponseModel<BasicDocumentTemplateDto>>
{
    public CompanyDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicDocumentTemplateDto>> Handle(GetCompanyDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = _applicationDbContext.DocumentTemplateCompanies
            .Include(x => x.DocumentTemplate)
            .Where(x => x.CompanyId == request.CompanyId);
        var selectedDocuments = await documents
            .Select(x => x.DocumentTemplate)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(selectedDocuments);
        return new TableResponseModel<BasicDocumentTemplateDto>(result, request.PageNumber, request.PageSize, documents.Count());
    }
}