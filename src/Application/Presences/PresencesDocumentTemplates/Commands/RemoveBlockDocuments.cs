﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public class RemoveBlockDocuments : IRequest<bool>
{
    public Guid  BlockId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class RemoveBlockDocumentsHandler : BaseCommandQueryHandler, IRequestHandler<RemoveBlockDocuments, bool>
{

    public RemoveBlockDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(RemoveBlockDocuments request, CancellationToken cancellationToken)
    {
        var document = _applicationDbContext.DocumentTemplateBlocks.FirstOrDefault(x => x.DocumentTemplateId == request.DocumentTemplateId && x.BlockId == request.BlockId);
        _applicationDbContext.DocumentTemplateBlocks.Remove(document);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}