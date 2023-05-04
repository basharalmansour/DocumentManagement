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
public class RemoveCompanyDocumentsCommand : IRequest<bool>
{
    public int CompanyId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveCompanyDocumentsHandler : BaseCommandHandler, IRequestHandler<RemoveCompanyDocumentsCommand, bool>
{

    public RemoveCompanyDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(RemoveCompanyDocumentsCommand request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateCompanies
            .FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.CompanyId == request.CompanyId);
        if (document == null)
            throw new Exception("DocumentTemplate was NOT found");
        _applicationDbContext.DocumentTemplateCompanies.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}