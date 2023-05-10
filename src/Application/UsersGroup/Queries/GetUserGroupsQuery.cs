using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static MassTransit.ValidationResultExtensions;

namespace CleanArchitecture.Application.UsersGroup.Queries;
public class GetUserGroupsQuery : TableRequestModel, IRequest<TableResponseModel<GetUserGroupDto>>
{
    public string SearchText { get; set; }
}

public class GetUserGroupQueryHandler : BaseQueryHandler, IRequestHandler<GetUserGroupsQuery, TableResponseModel<GetUserGroupDto>>
{

    public GetUserGroupQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }

    public async Task<TableResponseModel<GetUserGroupDto>> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
    {
        var userGroups = _applicationDbContext.UserGroups.Where(x => !x.IsDeleted);
        
        var selectedUserGroups = await userGroups
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        
        var userGroupsDto= _mapper.Map<List<GetUserGroupDto>>(selectedUserGroups);
        return new TableResponseModel<GetUserGroupDto>(userGroupsDto, request.PageNumber, request.PageSize, userGroups.Count());
    }
}
