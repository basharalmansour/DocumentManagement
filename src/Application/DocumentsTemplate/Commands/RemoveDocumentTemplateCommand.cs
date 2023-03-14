using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Commands;
public class RemoveDocumentTemplateCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class RemoveDocumentTemplateHandler : IRequestHandler<RemoveDocumentTemplateCommand,bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    public RemoveDocumentTemplateHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<bool> Handle(RemoveDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        var deletedDocumentTemplate= _applicationDbContext.DocumentTemplates.FirstOrDefault(x => x.Id == request.Id);
        deletedDocumentTemplate.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

