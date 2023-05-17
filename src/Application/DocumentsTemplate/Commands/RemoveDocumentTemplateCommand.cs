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
using CleanArchitecture.Domain.Entities.DocumentTemplates;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Commands;
public class RemoveDocumentTemplateCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class RemoveDocumentTemplateHandler : BaseCommandHandler, IRequestHandler<RemoveDocumentTemplateCommand,bool>
{
    public RemoveDocumentTemplateHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(RemoveDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        var deletedDocumentTemplate= _applicationDbContext.DocumentTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (deletedDocumentTemplate == null)
            throw new Exception("Document Template was NOT found");
        deletedDocumentTemplate.DeleteByUser();
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        //await _publishEndpoint.Publish(new DocumentTemplateRemoved
        //{
        //    DocumentTemplateId = request.Id
        //});
        return true;
    }
}

