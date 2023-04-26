using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class AddBrandDocuments : IRequest<bool>
{
    public int BrandId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddBrandDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<AddBrandDocuments, bool>
{

    public AddBrandDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(AddBrandDocuments request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateBrand>(request);
        _applicationDbContext.DocumentTemplateBrands.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}