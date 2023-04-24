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
public class AddBrandDocuments : IRequest<bool>
{
    public int BrandId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddBrandDocumentsHandler : IRequestHandler<AddBrandDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public AddBrandDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(AddBrandDocuments request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateBrand>(request);
        _applicationDbContext.DocumentTemplateBrands.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}