using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveBrandDocuments : IRequest<bool>
{
    public int BrandId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveBrandDocumentsHandler : IRequestHandler<RemoveBrandDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemoveBrandDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(RemoveBrandDocuments request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateBrands.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.BrandId == request.BrandId);
        _applicationDbContext.DocumentTemplateBrands.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}