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
public  class GetBlockServiceCategories : IRequest<List<BasicServiceCategoryDto>>
{
    public Guid BlockId { get; set; }
}
public class GetBlockServiceCategoriesHandler : BaseQueryHandler, IRequestHandler<GetBlockServiceCategories, List<BasicServiceCategoryDto>>
{
    public GetBlockServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetBlockServiceCategories request, CancellationToken cancellationToken)
    {
        var serviceCategories = await _applicationDbContext.ServiceCategoryBlocks
            .Include(x => x.ServiceCategory)
            .Where(x => x.BlockId == request.BlockId)
            .Select(x => x.ServiceCategory)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;
    }
}