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

namespace CleanArchitecture.Application.UsersGroup.Commands;

public class RemoveUserGroupCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class RemoveUserGroupCommandHandler : IRequestHandler<RemoveUserGroupCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemoveUserGroupCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(RemoveUserGroupCommand request, CancellationToken cancellationToken)
    {
        var userGroup =  _applicationDbContext.UserGroups.FirstOrDefault(x => x.Id == request.Id);
        userGroup.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;

    }
}
