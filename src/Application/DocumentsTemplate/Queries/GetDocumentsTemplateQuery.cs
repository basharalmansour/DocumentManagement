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

namespace CleanArchitecture.Application.DocumentsTemplate.Queries;
public class GetDocumentsTemplateQuery : IRequest<List<GetDocumentTemplateDto>>
{

}
public class GetDocumentsTemplateHandler : IRequestHandler<GetDocumentsTemplateQuery, List<GetDocumentTemplateDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetDocumentsTemplateHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<GetDocumentTemplateDto>> Handle(GetDocumentsTemplateQuery request, CancellationToken cancellationToken)
    {
        var documents =await  _applicationDbContext.DocumentTemplates.Where(x => x.IsDeleted == false).ToListAsync();
        var documentsDto = _mapper.Map< List<GetDocumentTemplateDto>>(documents);
        return documentsDto ;
    }
}
