using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PrecencesServiceCategories.Queries;
public  class GetAreaServiceCategoriesQuery : IRequest<List<BasicServiceCategoryDto>>
{
    public int AreaId { get; set; }
}
public class GetAreaServiceCategoriesHandler : BaseCommandQueryHandler, IRequestHandler<GetAreaServiceCategoriesQuery, List<BasicServiceCategoryDto>>
{
    public GetAreaServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetAreaServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var serviceCategories =await _applicationDbContext.ServiceCategoryAreas
            .Include(x=>x.ServiceCategory)
            .Where(x => x.AreaId ==request.AreaId)
            .Select(x => x.ServiceCategory)
            .ToListAsync();
        var result= _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;    
    }
}
