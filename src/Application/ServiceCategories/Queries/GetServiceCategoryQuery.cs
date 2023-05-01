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

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryQuery : IRequest<List<BasicServiceCategoryDto>>
{
    public string SearchText { get; set; }
}
public class GetServiceCategoryHandler : BaseQueryHandler, IRequestHandler<GetServiceCategoryQuery, List<BasicServiceCategoryDto>>
{

    public GetServiceCategoryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetServiceCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories =await _applicationDbContext.ServiceCategories
            .Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText))
            .Include(x=>x.SubServiceCategories.Where(x => !x.IsDeleted))
            .ToListAsync();
        var categoriesDto = _mapper.Map<List<BasicServiceCategoryDto>>(categories);
        return categoriesDto;
    }
}
