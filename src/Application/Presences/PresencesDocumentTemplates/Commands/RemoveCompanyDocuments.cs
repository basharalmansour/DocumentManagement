using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveCompanyDocuments : IRequest<bool>
{
    public int CompanyId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveCompanyDocumentsHandler : IRequestHandler<RemoveCompanyDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemoveCompanyDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(RemoveCompanyDocuments request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateCompanies.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.CompanyId == request.CompanyId);
        _applicationDbContext.DocumentTemplateCompanies.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}