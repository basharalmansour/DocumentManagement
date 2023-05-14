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

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryPersonnelDocumentsQuery : TableRequestModel, IRequest<TableResponseModel<BasicDocumentTemplateDto>>
{
    public int ServiceCategoryId { get; set; }
}
public class GetServiceCategoryPersonnelDocumentsHandler : BaseQueryHandler, IRequestHandler<GetServiceCategoryPersonnelDocumentsQuery, TableResponseModel<BasicDocumentTemplateDto>>
{
    public GetServiceCategoryPersonnelDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicDocumentTemplateDto>> Handle(GetServiceCategoryPersonnelDocumentsQuery request, CancellationToken cancellationToken)
    {
        var category = await _applicationDbContext.ServiceCategoryDetails
            .Include(x => x.PersonnelDocuments)
            .FirstOrDefaultAsync(x => x.Id == request.ServiceCategoryId);
        if (category == null)
            throw new Exception("Service Category was NOT found");

        var documents = category
            .PersonnelDocuments
            .Select(x => x.DocumentTemplate);
        var selectedDocument = documents
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(selectedDocument);
        return new TableResponseModel<BasicDocumentTemplateDto>(result, request.PageNumber, request.PageSize, documents.Count());
    }
}