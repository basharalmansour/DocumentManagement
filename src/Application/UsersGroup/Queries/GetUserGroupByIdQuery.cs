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
public class GetUserGroupByIdQuery : IRequest<GetUserGroupDto>
{
    public int Id { get; set; }
}

public class GetUserGroupByIdQueryHandler : BaseCommandQueryHandler, IRequestHandler<GetUserGroupByIdQuery, GetUserGroupDto>
{

    public GetUserGroupByIdQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }

    public async Task<GetUserGroupDto> Handle(GetUserGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var userGroup =await _applicationDbContext.UserGroups.Include(x=>x.Personnels).FirstOrDefaultAsync (x => x.Id == request.Id);
        var userGroupDto = _mapper.Map<GetUserGroupDto>(userGroup);
        return userGroupDto;
    }
}
