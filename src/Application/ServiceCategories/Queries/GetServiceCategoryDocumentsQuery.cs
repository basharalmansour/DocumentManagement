using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.DocumentsTemplate.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryDocumentsQuery : TableRequestModel, IRequest<TableResponseModel<BasicDocumentTemplateDto>>
{
    public int ServiceCategoryId { get; set; }
}
public class GetServiceCategoryDocumentsHandler : BaseQueryHandler, IRequestHandler<GetServiceCategoryDocumentsQuery, TableResponseModel<BasicDocumentTemplateDto>>
{
    public GetServiceCategoryDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicDocumentTemplateDto>> Handle(GetServiceCategoryDocumentsQuery request, CancellationToken cancellationToken)
    {
        var category = await _applicationDbContext.ServiceCategoryDetails
            .Include(x => x.Documents)
            .FirstOrDefaultAsync(x => x.Id == request.ServiceCategoryId);
        if (category == null)
            throw new Exception("Service Category was NOT found");

        var documents = category
            .Documents
            .Select(x => x.DocumentTemplate);
        var selectedDocument = documents
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(selectedDocument);
        return new TableResponseModel<BasicDocumentTemplateDto>(result, request.PageNumber, request.PageSize, documents.Count());
    }
}