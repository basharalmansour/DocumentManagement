using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryByIdQuery : IRequest<ServiceCategoryDto>
{
    public int Id { get; set; }
}
public class ServiceCategoryByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetServiceCategoryByIdQuery, ServiceCategoryDto>
{
    public ServiceCategoryByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<ServiceCategoryDto> Handle(GetServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var categoryDetails = await _applicationDbContext.ServiceCategoryDetails
            .Include(x=>x.ServiceCategory.SubServiceCategories.Where(x => !x.IsDeleted))
            .Include(x => x.VehicleTemplates)
            .Include(x => x.Documents)
            .Include(x => x.PersonnelDocuments)
            .Include(x => x.ServiceCategoryAreas)
            .Include(x => x.ServiceCategoryBlocks)
            .Include(x => x.ServiceCategoryBrands)
            .Include(x => x.ServiceCategoryCompanies)
            .Include(x => x.ServiceCategorySites)
            .Include(x => x.ServiceCategoryUnits)
            .Include(x => x.ServiceCategoryZones)
            .Include(x => x.ServiceCategoryPresenceGroups)
            .Include(x => x.ServiceCategoryRoles)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (categoryDetails == null)
            throw new Exception("Service Category was NOT found");
        var categoryDto = _mapper.Map<ServiceCategoryDto>(categoryDetails.ServiceCategory);
        return categoryDto; 
    }
}
