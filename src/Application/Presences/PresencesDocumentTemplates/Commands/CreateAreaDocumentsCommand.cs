using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class CreateAreaDocumentsCommand : IRequest<bool>
{
    public int AreaId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddAreaDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<CreateAreaDocumentsCommand, bool>
{

    public AddAreaDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }
    public async Task<bool> Handle(CreateAreaDocumentsCommand request, CancellationToken cancellationToken)
    {
        var documents=_mapper.Map<DocumentTemplateArea>(request);
        _applicationDbContext.DocumentTemplateAreas.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;    
    }
}
