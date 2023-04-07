using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryQuery : IRequest<List<GetServiceCategoryDto>>
{
    public string SearchText { get; set; }
}
public class GetServiceCategoryHandler : IRequestHandler<GetServiceCategoryQuery, List<GetServiceCategoryDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetServiceCategoryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<GetServiceCategoryDto>> Handle(GetServiceCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories =await _applicationDbContext.ServiceCategories
            .Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText))
            .Include(x => x.SubServiceCategories.Where(x=>x.IsDeleted==false))
            .Include(x=>x.SpecialRules)
            .Include(x=>x.Vehicles).ThenInclude(x=>x.VehicleDocuments)
            .Include(x=>x.Documents)
            .Include(x=>x.PersonnelDocuments)
            .Include(x=>x.ServiceCategoryAreas)
            .Include(x => x.ServiceCategoryBlocks)
            .Include(x => x.ServiceCategoryBrands )
            .Include(x => x.ServiceCategoryCompanies)
            .Include(x => x.ServiceCategorySites)
            .Include(x => x.ServiceCategoryUnits)
            .Include(x => x.ServiceCategoryZones) 
            .ToListAsync();
        var categoriesDto = _mapper.Map<List<GetServiceCategoryDto>>(categories);
        return categoriesDto;
    }
}
