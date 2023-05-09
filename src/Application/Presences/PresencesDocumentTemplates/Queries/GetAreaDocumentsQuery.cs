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

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
public class GetAreaDocumentsQuery :TableRequestModel, IRequest<TableResponseModel<BasicDocumentTemplateDto>>
{
    public int AreaId { get; set; }
}
public class AreaDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<GetAreaDocumentsQuery, TableResponseModel<BasicDocumentTemplateDto>>
{
    public AreaDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicDocumentTemplateDto>> Handle(GetAreaDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents =  _applicationDbContext.DocumentTemplateAreas
            .Include(x => x.DocumentTemplate)
            .Where(x => x.AreaId == request.AreaId);
        var selectedDocuments= await documents
            .Select(x => x.DocumentTemplate)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(selectedDocuments);
        return new TableResponseModel<BasicDocumentTemplateDto>(result, request.PageNumber, request.PageSize, documents.Count());
    }
}