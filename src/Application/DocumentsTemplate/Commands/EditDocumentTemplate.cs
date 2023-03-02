using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Commands;
public class EditDocumentTemplate : IRequest<int>
{
    public EditDocumentTemplateRequest DocumentTemplate { get; set; }
}

public class EditDocumentTemplateHandler : IRequestHandler<EditDocumentTemplate, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public EditDocumentTemplateHandler(IMapper mapper, IApplicationDbContext applicationDbContext = null)
    {
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(EditDocumentTemplate request, CancellationToken cancellationToken)
    {
        var documentTemplate = _applicationDbContext.DocumentTemplates.FirstOrDefault(x => x.Id == request.DocumentTemplate.Id & x.IsDeleted == false);
        _mapper.Map(request.DocumentTemplate, documentTemplate);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
