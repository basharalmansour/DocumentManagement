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

namespace CleanArchitecture.Application.UsersGroup.Commands;

public class RemoveUserGroupCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class RemoveUserGroupCommandHandler : BaseCommandQueryHandler, IRequestHandler<RemoveUserGroupCommand, bool>
{
    public RemoveUserGroupCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }

    public async Task<bool> Handle(RemoveUserGroupCommand request, CancellationToken cancellationToken)
    {
        var userGroup =  _applicationDbContext.UserGroups.FirstOrDefault(x => x.Id == request.Id);
        userGroup.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;

    }
}
