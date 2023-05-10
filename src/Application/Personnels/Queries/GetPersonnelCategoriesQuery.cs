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

namespace CleanArchitecture.Application.Personnels.Queries;
public class GetPersonnelCategoriesQuery : IRequest<UserGroupApproversDto>
{
    public int PresonnelId { get; set; }
}
public class GetPersonnelCategoriesQueryHandler : BaseQueryHandler, IRequestHandler<GetPersonnelCategoriesQuery, UserGroupApproversDto>
{
    public GetPersonnelCategoriesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<UserGroupApproversDto> Handle(GetPersonnelCategoriesQuery request, CancellationToken cancellationToken)
    {
        UserGroupApproversDto result = new UserGroupApproversDto();
        var categories = await _applicationDbContext.ResponsiblePersonnels
            .Where(x => x.PersonnelId == request.PresonnelId)
            .Select(x => x.ServiceCategoryRole.ServiceCategory)
            .ToListAsync();
        result.ServiceCategories = _mapper.Map<List<BasicServiceCategoryDto>>(categories);
        result.PersonnelId = request.PresonnelId;
        return result;
    }
}