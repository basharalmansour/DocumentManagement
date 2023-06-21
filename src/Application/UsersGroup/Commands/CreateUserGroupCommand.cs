using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.UserGroups;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.UsersGroup.Commands;

public class CreateUserGroupCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public List<int> PersonnelIds { get; set; }
}

public class CreateUserGroupCommandHandler : BaseCommandHandler, IRequestHandler<CreateUserGroupCommand, int>
{
    public CreateUserGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<int> Handle(CreateUserGroupCommand request, CancellationToken cancellationToken)
    {
        var userGroup = _mapper.Map<UserGroup>(request);
        userGroup.UniqueCode = UniqueCode.CreateUniqueCode(8, false,"U");
        _applicationDbContext.UserGroups.Add(userGroup);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return userGroup.Id;
    }
}

