using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Queries;

public class GetDocumentTemplateByIdQuery : IRequest<GetDocumentTemplateDto>
{
    public int Id { get; set; }
}
public class GetDocumentTemplateByIdHandler : IRequestHandler<GetDocumentTemplateByIdQuery, GetDocumentTemplateDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetDocumentTemplateByIdHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<GetDocumentTemplateDto> Handle(GetDocumentTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var document = await _applicationDbContext.DocumentTemplates.Include(x=>x.DocumentTemplateFileTypes).FirstOrDefaultAsync(x=>x.Id==request.Id);
        var documentDto = _mapper.Map<GetDocumentTemplateDto>(document);
        return documentDto;
    }
}
