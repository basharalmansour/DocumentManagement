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
public class ServiceCategoryByIdQuery : IRequest<GetServiceCategoryDto>
{
    public int Id { get; set; }
}
public class ServiceCategoryByIdQueryHandler : IRequestHandler<ServiceCategoryByIdQuery, GetServiceCategoryDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public ServiceCategoryByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<GetServiceCategoryDto> Handle(ServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {

        var category = await _applicationDbContext.ServiceCategories.Include(x => x.SubServiceCategories.Where(x => x.IsDeleted == false)).FirstOrDefaultAsync(x=>x.Id==request.Id);
        var specialRuleIds = _applicationDbContext.CategorySpecialRules.Where(x => x.ServiceCategoryId == category.Id).Select(x=>x.Id).ToList();
        var categoryDto = _mapper.Map<GetServiceCategoryDto>(category);

        categoryDto.IsParallel = _applicationDbContext.ServiceCategoryApprovments.FirstOrDefault(x => x.Id == category.ServiceCategoryApprovmentId).IsParallel;
        categoryDto.PersonnelApproversIds = _applicationDbContext.ApproverPersonnels.Where(x => x.ServiceCategoryApprovmentId == category.ServiceCategoryApprovmentId).Select(x=>x.PersonnelId).ToList();
        categoryDto.DepartmentApproversIds = _applicationDbContext.ApproverDepartments.Where(x => x.ServiceCategoryApprovmentId == category.ServiceCategoryApprovmentId).Select(x => x.DepartmentId).ToList();
        categoryDto.UserGroupApproversIds = _applicationDbContext.ApproverUserGroups.Where(x => x.ServiceCategoryApprovmentId == category.ServiceCategoryApprovmentId).Select(x => x.UserGroupId).ToList();
        foreach (var id in specialRuleIds)
            categoryDto.SpecialRuleNames.Add(_applicationDbContext.SpecialRules.FirstOrDefault(x => x.Id == id).Name); 
        return categoryDto; 
    }
}
