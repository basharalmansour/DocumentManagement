using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Queries;
public class GetDocumentTemplatesQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public string SearchText { get; set; }
}
public class GetDocumentsTemplateHandler : BaseQueryHandler, IRequestHandler<GetDocumentTemplatesQuery, List<BasicDocumentTemplateDto>>
{
    public GetDocumentsTemplateHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(GetDocumentTemplatesQuery request, CancellationToken cancellationToken)
    {
        var documents = await  _applicationDbContext.DocumentTemplates.Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText)).ToListAsync();
        var documentsDto = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        
        //in case that just one lanuage is needed
        documentsDto.ForEach(x => x.Name.KeepOneLanguage(LanguageCode.tr));

        return documentsDto ;
    }
}