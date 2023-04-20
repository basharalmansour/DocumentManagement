using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Queries;
public class GetDocumentTemplateTypesQuery : IRequest<List<KeyValuePair<int,string>>>
{
}
public class GetDocumentTemplateTypesHandler : IRequestHandler<GetDocumentTemplateTypesQuery, List<KeyValuePair<int, string>>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetDocumentTemplateTypesHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<KeyValuePair<int, string>>> Handle(GetDocumentTemplateTypesQuery request, CancellationToken cancellationToken)
    {
        var documentTypes = await _applicationDbContext.DocumentTemplateTypes.Select(x=> new KeyValuePair<int, string>(x.Id,x.Name)).ToListAsync();
        return documentTypes;
    }
}
