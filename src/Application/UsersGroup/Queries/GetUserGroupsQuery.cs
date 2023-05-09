using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UsersGroup.Queries;
public class GetUserGroupsQuery : IRequest<List<GetUserGroupDto>>
{
    public string SearchText { get; set; }
}

public class GetUserGroupQueryHandler : BaseQueryHandler, IRequestHandler<GetUserGroupsQuery, List<GetUserGroupDto>>
{

    public GetUserGroupQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }

    public async Task<List<GetUserGroupDto>> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
    {
        var userGroups =await _applicationDbContext.UserGroups.Where(x => x.IsDeleted == false).ToListAsync();
        
        var userGroupsDto= _mapper.Map<List<GetUserGroupDto>>(userGroups);
        return userGroupsDto;
    }
}
