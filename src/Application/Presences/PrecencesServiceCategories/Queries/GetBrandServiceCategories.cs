using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PrecencesServiceCategories.Queries;
public  class GetBrandServiceCategories : IRequest<List<BasicServiceCategoryDto>>
{
    public int  BrandId { get; set; }
}
public class GetBrandServiceCategoriesHandler : BaseQueryHandler, IRequestHandler<GetBrandServiceCategories, List<BasicServiceCategoryDto>>
{
    public GetBrandServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetBrandServiceCategories request, CancellationToken cancellationToken)
    {
        var serviceCategories = await _applicationDbContext.ServiceCategoryBrands
            .Include(x => x.ServiceCategory)
            .Where(x => x.BrandId == request.BrandId)
            .Select(x => x.ServiceCategory)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;
    }
}
