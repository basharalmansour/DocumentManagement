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
public class PresenceGroupDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int PresenceGroupId { get; set; }
}
public class PresenceGroupDocumentsQueryHandler : BaseCommandQueryHandler, IRequestHandler<PresenceGroupDocumentsQuery, List<BasicDocumentTemplateDto>>
{

    public PresenceGroupDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(PresenceGroupDocumentsQuery request, CancellationToken cancellationToken)
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