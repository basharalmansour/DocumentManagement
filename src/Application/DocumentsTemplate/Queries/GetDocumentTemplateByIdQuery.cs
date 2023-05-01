using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Queries;

public class GetDocumentTemplateByIdQuery : IRequest<GetDocumentTemplateDto>//
{
    public int Id { get; set; }
}
public class GetDocumentTemplateByIdHandler : BaseQueryHandler, IRequestHandler<GetDocumentTemplateByIdQuery, GetDocumentTemplateDto>
{
    public GetDocumentTemplateByIdHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<GetDocumentTemplateDto> Handle(GetDocumentTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var document = await _applicationDbContext.DocumentTemplates
            .Include(x=>x.DocumentTemplateFileTypes)
            .Include(x=>x.Forms)
            .FirstOrDefaultAsync(x=>x.Id==request.Id);
        var documentDto = _mapper.Map<GetDocumentTemplateDto>(document);
        return documentDto;
    }
}
