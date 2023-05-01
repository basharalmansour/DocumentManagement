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
public  class GetBlockServiceCategoriesQuery : IRequest<List<BasicServiceCategoryDto>>
{
    public Guid BlockId { get; set; }
}
public class GetBlockServiceCategoriesHandler : BaseCommandQueryHandler, IRequestHandler<GetBlockServiceCategoriesQuery, List<BasicServiceCategoryDto>>
{
    public GetBlockServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetBlockServiceCategoriesQuery request, CancellationToken cancellationToken)
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