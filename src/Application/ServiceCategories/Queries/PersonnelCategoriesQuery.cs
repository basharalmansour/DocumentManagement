using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class PersonnelCategoriesQuery : IRequest<UserGroupApproversDto>
{
    public int PresonnelId { get; set; }
}
public class PersonnelCategoriesQueryHandler : BaseQueryHandler, IRequestHandler<PersonnelCategoriesQuery, UserGroupApproversDto>
{
    public PersonnelCategoriesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<UserGroupApproversDto> Handle(PersonnelCategoriesQuery request, CancellationToken cancellationToken)
    {
        UserGroupApproversDto result = new UserGroupApproversDto();
        var categories=await _applicationDbContext.ApproverPersonnels
            .Where(x => x.PersonnelId== request.PresonnelId)
            .Select(x => x.ServiceCategoryRole.ServiceCategory)
            .ToListAsync();
        result.ServiceCategories = _mapper.Map<List<BasicServiceCategoryDto>>(categories);
        result.PersonnelId = request.PresonnelId;
        return result;
    }
}