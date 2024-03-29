﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.DocumentsTemplate.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int ServiceCategoryId { get; set; }
}
public class GetServiceCategoryDocumentsHandler : BaseQueryHandler, IRequestHandler<GetServiceCategoryDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    public GetServiceCategoryDocumentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(GetServiceCategoryDocumentsQuery request, CancellationToken cancellationToken)
    {
        var category = await _applicationDbContext.ServiceCategoryDetails
            .Include(x => x.Documents)
            .ThenInclude(x => x.DocumentTemplate)
            .FirstOrDefaultAsync(x => x.Id == request.ServiceCategoryId);
        if (category == null)
            throw new Exception("Service Category was NOT found");

        var documents = category
            .Documents
            .Select(x => x.DocumentTemplate)
            .ToList();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}