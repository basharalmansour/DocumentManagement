using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UsersGroup.Queries;
public class GetUserGroupQuery : IRequest<List<GetUserGroupDto>>
{
}

public class GetUserGroupQueryHandler : IRequestHandler<GetUserGroupQuery, List<GetUserGroupDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetUserGroupQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<List<GetUserGroupDto>> Handle(GetUserGroupQuery request, CancellationToken cancellationToken)
    {
        var userGroups =await _applicationDbContext.UserGroups.Where(x => x.IsDeleted == false).ToListAsync();
        var userGroupsDto= _mapper.Map<List<GetUserGroupDto>>(userGroups);
        return userGroupsDto;

    }
}
