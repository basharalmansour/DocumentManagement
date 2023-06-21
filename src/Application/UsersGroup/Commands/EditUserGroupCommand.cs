using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.UserGroups;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.UsersGroup.Commands;
public class EditUserGroupCommand :CreateUserGroupCommand , IRequest<int>
{
    public int UserGroupId { get; set; }
}

public class EditUserGroupCommandHandler : BaseCommandHandler, IRequestHandler<EditUserGroupCommand, int>
{

    public EditUserGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<int> Handle(EditUserGroupCommand request, CancellationToken cancellationToken)
    {
        var userGroup = _applicationDbContext.UserGroups.FirstOrDefault(x => x.Id == request.UserGroupId);
        if (userGroup == null)
            throw new Exception("UserGroup was NOT found");
        userGroup.DeleteByEdit();
        var newUserGroup = _mapper.Map<UserGroup>((CreateUserGroupCommand)request);
        newUserGroup.UniqueCode = userGroup.UniqueCode;
        _applicationDbContext.UserGroups.Add(newUserGroup);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newUserGroup.Id;
    }
}
