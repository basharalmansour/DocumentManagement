﻿using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Queries;
public class GetDocumentTemplatesQuery :TableRequestModel , IRequest<TableResponseModel<BasicDocumentTemplateDto>>
{
    public string SearchText { get; set; }
}
public class GetDocumentsTemplateHandler : BaseQueryHandler, IRequestHandler<GetDocumentTemplatesQuery, TableResponseModel<BasicDocumentTemplateDto>>
{
    public GetDocumentsTemplateHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicDocumentTemplateDto>> Handle(GetDocumentTemplatesQuery request, CancellationToken cancellationToken)
    {
        var documents =   _applicationDbContext.DocumentTemplates
            .Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase));
        var selectedDocument =await documents
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var documentsDto = _mapper.Map<List<BasicDocumentTemplateDto>>(selectedDocument);
        return new TableResponseModel<BasicDocumentTemplateDto>(documentsDto, request.PageNumber, request.PageSize, documents.Count());
    }
}