using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Commands;
public class EditDocumentTemplateCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DocumentTemplateTypeId { get; set; }
    public List<DocumentFileType> DocumentFileType { get; set; }
    public bool HasValidationDate { get; set; }
    public string UniqueCode { get; set; }
}

public class EditDocumentTemplateCommandHandler : IRequestHandler<EditDocumentTemplateCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public EditDocumentTemplateCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext = null)
    {
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<int> Handle(EditDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        var documentTemplate = _applicationDbContext.DocumentTemplates.FirstOrDefault(x => x.Id == request.Id & x.IsDeleted == false);
        _mapper.Map(request, documentTemplate);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return documentTemplate.Id;
        
    }
}
