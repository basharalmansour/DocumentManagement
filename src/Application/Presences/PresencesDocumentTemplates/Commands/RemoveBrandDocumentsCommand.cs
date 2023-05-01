using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveBrandDocumentsCommand : IRequest<bool>
{
    public int BrandId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveBrandDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<RemoveBrandDocumentsCommand, bool>
{
    public RemoveBrandDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(RemoveBrandDocumentsCommand request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateBrands.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.BrandId == request.BrandId);
        _applicationDbContext.DocumentTemplateBrands.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}