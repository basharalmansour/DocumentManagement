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

namespace CleanArchitecture.Application.Presences.PresenceGroups.Queries;
public class GetPresenceGroupDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int PresenceGroupId { get; set; }
}
public class GetPresenceGroupDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<GetPresenceGroupDocumentsQuery, List<BasicDocumentTemplateDto>>
{

    public GetPresenceGroupDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(GetPresenceGroupDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _applicationDbContext.DocumentTemplatePresenceGroups
            .Include(x => x.DocumentTemplate)
            .Where(x => x.PresenceGroupId == request.PresenceGroupId)
            .Select(x => x.DocumentTemplate)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}