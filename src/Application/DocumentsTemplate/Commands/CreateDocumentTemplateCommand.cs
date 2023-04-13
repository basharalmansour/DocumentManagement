using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.DocumentsTemplate.Commands;
public class CreateDocumentTemplateCommand : IRequest<int>
{
    public string Name { get; set; }
    public int DocumentTemplateTypeId { get; set; }
    public List<DocumentFileType> DocumentTemplateFileTypes { get; set; }
    public bool HasValidationDate { get; set; }
}

public class CreateDocumentTemplateCommandHandler :IRequestHandler<CreateDocumentTemplateCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public CreateDocumentTemplateCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext = null)
    {
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<int> Handle(CreateDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        UniqueCode code = new UniqueCode(8, false);
        var documentTemplate = _mapper.Map<DocumentTemplate>(request);
        documentTemplate.UniqueCode= "D"+ code.CreateUniqueCode(8, false);
        _applicationDbContext.DocumentTemplates.Add(documentTemplate);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return documentTemplate.Id; 
    }
}