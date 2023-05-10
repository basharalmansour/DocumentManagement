using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Queries;
public class GetPresenceGroupDocumentsQuery : TableRequestModel, IRequest<TableResponseModel<BasicDocumentTemplateDto>>
{
    public int PresenceGroupId { get; set; }
}
public class GetPresenceGroupDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<GetPresenceGroupDocumentsQuery, TableResponseModel<BasicDocumentTemplateDto>>
{

    public GetPresenceGroupDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<TableResponseModel<BasicDocumentTemplateDto>> Handle(GetPresenceGroupDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents =  _applicationDbContext.DocumentTemplatePresenceGroups
            .Include(x => x.DocumentTemplate)
            .Where(x => x.PresenceGroupId == request.PresenceGroupId);
        var selectedDocuments=await documents
            .Select(x => x.DocumentTemplate)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(selectedDocuments);
        return new TableResponseModel<BasicDocumentTemplateDto>(result, request.PageNumber, request.PageSize, documents.Count());
    }
}