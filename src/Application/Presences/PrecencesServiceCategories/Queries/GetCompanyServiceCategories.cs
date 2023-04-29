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
public  class GetCompanyServiceCategories : IRequest<List<BasicServiceCategoryDto>>
{
    public int CompanyId { get; set; }
}
public class GetCompanyServiceCategoriesHandler : BaseCommandQueryHandler, IRequestHandler<GetCompanyServiceCategories, List<BasicServiceCategoryDto>>
{
    public GetCompanyServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetCompanyServiceCategories request, CancellationToken cancellationToken)
    {
        var serviceCategories = await _applicationDbContext.ServiceCategoryCompanies
            .Include(x => x.ServiceCategory)
            .Where(x => x.CompanyId == request.CompanyId)
            .Select(x => x.ServiceCategory)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;
    }
}