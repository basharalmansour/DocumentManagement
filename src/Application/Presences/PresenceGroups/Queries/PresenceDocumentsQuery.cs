using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Documents;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Queries;
public class PresenceDocumentsQuery : IRequest<List<GetDocumentTemplateDto>>
{
    public int Id { get; set; }
}
public class PresenceDocumentsQueryHandler : IRequestHandler<PresenceDocumentsQuery, List<GetDocumentTemplateDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public PresenceDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<GetDocumentTemplateDto>> Handle(PresenceDocumentsQuery request, CancellationToken cancellationToken)
    {
        List<DocumentTemplate> result = new List<DocumentTemplate>();
        var documentsIds = _applicationDbContext.DocumentTemplatePresenceGroups.Where(x => x.PresenceGroupId == request.Id).Select(x => x.DocumentTemplateId).ToList();
        foreach (int id in documentsIds)
        {
            var document = _applicationDbContext.DocumentTemplates.FirstOrDefault(x => x.Id == id);
            result.Add(document);
        }
        var resultDto = _mapper.Map<List<GetDocumentTemplateDto>>(result);
        return resultDto;
    }
}
