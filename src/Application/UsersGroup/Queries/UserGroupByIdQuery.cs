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
public class UserGroupByIdQuery : IRequest<GetUserGroupDto>
{
    public int Id { get; set; }
}

public class UserGroupByIdQueryHandler : IRequestHandler<UserGroupByIdQuery, GetUserGroupDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public UserGroupByIdQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<GetUserGroupDto> Handle(UserGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var userGroup =await _applicationDbContext.UserGroups.FirstOrDefaultAsync (x => x.Id == request.Id);
        var userGroupDto = _mapper.Map<GetUserGroupDto>(userGroup);
        return userGroupDto;
    }
}
