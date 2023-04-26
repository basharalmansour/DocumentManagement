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
public class ServiceCategoryByIdQuery : IRequest<ServiceCategoryDetailsDto>
{
    public int Id { get; set; }
}
public class ServiceCategoryByIdQueryHandler : BaseCommandQueryHandler, IRequestHandler<ServiceCategoryByIdQuery, ServiceCategoryDetailsDto>
{
    public ServiceCategoryByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<ServiceCategoryDetailsDto> Handle(ServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {

        var category = await _applicationDbContext.ServiceCategories
            .Include(x => x.SubServiceCategories.Where(x => x.IsDeleted == false))
            .Include(x => x.SpecialRules)
            .Include(x => x.Vehicles)
            .Include(x => x.Documents)
            .Include(x => x.ServiceCategoryAreas)
            .Include(x => x.ServiceCategoryBlocks)
            .Include(x => x.ServiceCategoryBrands)
            .Include(x => x.ServiceCategoryCompanies)
            .Include(x => x.ServiceCategorySites)
            .Include(x => x.ServiceCategoryUnits)
            .Include(x => x.ServiceCategoryZones)
            .FirstOrDefaultAsync(x=>x.Id==request.Id);
        var specialRuleIds = _applicationDbContext.CategorySpecialRoles.Where(x => x.ServiceCategoryId == category.Id).Select(x=>x.Id).ToList();

        var categoryDto = _mapper.Map<ServiceCategoryDetailsDto>(category);
        return categoryDto; 
    }
}
