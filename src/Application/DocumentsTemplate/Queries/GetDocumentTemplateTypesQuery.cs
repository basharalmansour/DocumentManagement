using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Queries;
public class GetDocumentTemplateTypesQuery : TableRequestModel, IRequest<TableResponseModel<KeyValuePair<int,string>>>
{
}
public class GetDocumentTemplateTypesHandler : BaseQueryHandler, IRequestHandler<GetDocumentTemplateTypesQuery, TableResponseModel<KeyValuePair<int, string>>>
{
    public GetDocumentTemplateTypesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<KeyValuePair<int, string>>> Handle(GetDocumentTemplateTypesQuery request, CancellationToken cancellationToken)
    {
        var documentTypes = await _applicationDbContext.DocumentTemplateTypes
            .ToListAsync();
        var selectedDocumentTypes = documentTypes
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
        return new TableResponseModel<KeyValuePair<int, string>> (selectedDocumentTypes, request.PageNumber, request.PageSize, documentTypes.Count());
    }
}
