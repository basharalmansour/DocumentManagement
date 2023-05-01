using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;
using MessageBroker.Events.DocumentTemplates;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.DocumentsTemplate.Commands;
public class CreateDocumentTemplateCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public int DocumentTemplateTypeId { get; set; }
    public List<DocumentFileType> DocumentTemplateFileTypes { get; set; }
    public bool HasValidationDate { get; set; }
    public List<int> Forms { get; set; }
}

public class CreateDocumentTemplateCommandHandler : BaseCommandHandler, IRequestHandler<CreateDocumentTemplateCommand, int>
{
    public CreateDocumentTemplateCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext,mapper, publishEndpoint)
    {
    }

    public async Task<int> Handle(CreateDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        var documentTemplate = _mapper.Map<DocumentTemplate>(request);
        documentTemplate.UniqueCode = UniqueCode.CreateUniqueCode(8, false, "D");
        _applicationDbContext.DocumentTemplates.Add(documentTemplate);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return documentTemplate.Id; 
    }
}