using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.DocumentTemplates;
using CleanArchitecture.Domain.Entities.Forms;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Commands;
public class EditDocumentTemplateCommand : CreateDocumentTemplateCommand, IRequest<int>
{
    public int Id { get; set; }
}

public class EditDocumentTemplateCommandHandler : BaseCommandHandler, IRequestHandler<EditDocumentTemplateCommand, int>
{
    public EditDocumentTemplateCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<int> Handle(EditDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        var documentTemplate = _applicationDbContext.DocumentTemplates
            .Include(x => x.DocumentTemplateFileTypes)
            .Include(x => x.Forms)
            .FirstOrDefault(x => x.Id == request.Id & x.IsDeleted == false);
        if (documentTemplate == null)
            throw new Exception ("Document Template was NOT found");

        documentTemplate.DeleteByEdit();
        var newDocumentTemplate = _mapper.Map<DocumentTemplate>((CreateDocumentTemplateCommand)request);
        newDocumentTemplate.UniqueCode = documentTemplate.UniqueCode;
        _applicationDbContext.DocumentTemplates.Add(newDocumentTemplate);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newDocumentTemplate.Id;
    }
}