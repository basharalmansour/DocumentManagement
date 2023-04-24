﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
public  class AddBlockDocuments : IRequest<bool>
{
    public Guid BlockId { get; set; }
    public int DocumentTemplateId { get; set; }
}
public class AddBlockDocumentsHandler : IRequestHandler<AddBlockDocuments, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public AddBlockDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(AddBlockDocuments request, CancellationToken cancellationToken)
    {
        var documents = _mapper.Map<DocumentTemplateBlock>(request);
        _applicationDbContext.DocumentTemplateBlocks.Add(documents);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}