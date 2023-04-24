using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class AddCompanyDocuments : IRequest<bool>
{
    public int CompanyId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddCompanyDocumentsHandler : IRequestHandler<AddCompanyDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public AddCompanyDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(AddCompanyDocuments request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateCompany>(request);
        _applicationDbContext.DocumentTemplateCompanies.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
