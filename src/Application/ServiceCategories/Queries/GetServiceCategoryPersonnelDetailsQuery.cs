using System;
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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryPersonnelDetailsQuery : IRequest<GetServiceCategoryPersonnelDetailsDto>
{
    public int ServiceCategoryId { get; set; }
}
public class GetServiceCategoryPersonnelDetailsHandler : BaseQueryHandler, IRequestHandler<GetServiceCategoryPersonnelDetailsQuery, GetServiceCategoryPersonnelDetailsDto>
{
    public GetServiceCategoryPersonnelDetailsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<GetServiceCategoryPersonnelDetailsDto> Handle(GetServiceCategoryPersonnelDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await _applicationDbContext.ServiceCategoryDetails
            .Include(x => x.PersonnelDocuments)
            .ThenInclude(x=>x.DocumentTemplate)
            .FirstOrDefaultAsync(x => x.Id == request.ServiceCategoryId);
        if (category == null)
            throw new Exception("Service Category was NOT found");

        var documents = category
            .PersonnelDocuments
            .Select(x => x.DocumentTemplate)
            .Distinct()
            .ToList();
        var result = new GetServiceCategoryPersonnelDetailsDto()
        {
            MaxPersonnelCount = category.MaxPersonnelCount,
            Documents = _mapper.Map<List<BasicDocumentTemplateDto>>(documents)
        };
        return result;
    }
}