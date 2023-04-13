using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class PersonnelCategoriesQuery : IRequest<UserGroupApproversDto>
{
    public int PresonnelId { get; set; }
}
public class PersonnelCategoriesQueryHandler : IRequestHandler<PersonnelCategoriesQuery, UserGroupApproversDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public PersonnelCategoriesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<UserGroupApproversDto> Handle(PersonnelCategoriesQuery request, CancellationToken cancellationToken)
    {
        UserGroupApproversDto result = new UserGroupApproversDto();
        var categories=await _applicationDbContext.ApproverPersonnels
            .Where(x => x.PersonnelId== request.PresonnelId)
            .Select(x => x.ServiceCategoryApprovment.ServiceCategory)
            .ToListAsync();
        result.CategoryIds = categories.Select(x => x.Id).ToList();
        result.CategoryNames = categories.Select(x => x.Name).ToList();
        result.PersonnelId = request.PresonnelId;
        return result;
    }
}
