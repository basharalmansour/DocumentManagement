using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveBrandDocumentsCommand : IRequest<bool>
{
    public int BrandId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveBrandDocumentsHandler : BaseCommandHandler, IRequestHandler<RemoveBrandDocumentsCommand, bool>
{
    public RemoveBrandDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(RemoveBrandDocumentsCommand request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateBrands.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.BrandId == request.BrandId);
        if (document == null)
            throw new Exception("DocumentTemplate was NOT found");
        _applicationDbContext.DocumentTemplateBrands.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}