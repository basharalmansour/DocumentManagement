﻿using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.DocumentTemplates;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Vendors;
using LinqKit;
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
        var predicate = PredicateBuilder.New<DocumentTemplate>();
        predicate = predicate.And(x => x.IsDeleted==false);
        if (!string.IsNullOrEmpty(request.SearchText))
            predicate = predicate.And(x => x.Name.ToLower().Contains(request.SearchText.ToLower()));
        var documents =   _applicationDbContext.DocumentTemplates
            .Where(predicate);
        var selectedDocument = documents
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
        var documentsDto = _mapper.Map<List<BasicDocumentTemplateDto>>(selectedDocument);
        return new TableResponseModel<BasicDocumentTemplateDto>(documentsDto, request.PageNumber, request.PageSize, documents.Count());
    }
}