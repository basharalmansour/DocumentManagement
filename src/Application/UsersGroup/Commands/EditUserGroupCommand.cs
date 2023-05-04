using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.UserGroups;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UsersGroup.Commands;
public class EditUserGroupCommand :CreateUserGroupCommand , IRequest<bool>
{
    public int Id { get; set; }
}

public class EditUserGroupCommandHandler : BaseCommandHandler, IRequestHandler<EditUserGroupCommand, bool>
{

    public EditUserGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(EditUserGroupCommand request, CancellationToken cancellationToken)
    {
        var userGroup = _applicationDbContext.UserGroups.FirstOrDefault(x => x.Id == request.Id);
        if (userGroup == null)
            await NullHandleProcesser.ExeptionsThrow("UserGroup");
        var newPresonnels = request.PersonnelIds.ToList();

        foreach (var id in userGroup.Personnels.Select(x => x.PersonnelId))
            if (newPresonnels.Any(x => x == id) == false)
            {
                var deletedPersonnelUserGroup = _applicationDbContext.UserGroupPersonnels.FirstOrDefault(x => x.PersonnelId == id);
                _applicationDbContext.UserGroupPersonnels.Remove(deletedPersonnelUserGroup);
            }
        _mapper.Map(userGroup , request);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
