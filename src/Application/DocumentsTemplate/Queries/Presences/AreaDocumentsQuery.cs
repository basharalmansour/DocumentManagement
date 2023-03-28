﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DocumentsTemplate.Queries.Presences;
public class AreaDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int AreaId { get; set; }
}
public class AreaDocumentsQueryHandler : IRequestHandler<AreaDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public AreaDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(AreaDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents =await _applicationDbContext.DocumentTemplateAreas.Where(x => x.AreaId == request.AreaId).Select(x => x.DocumentTemplate).ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}