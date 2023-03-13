using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UserGroups;
using MediatR;

namespace CleanArchitecture.Application.UsersGroup.Commands;

public class CreateUserGroupCommand : IRequest<int>
{
    public string Name { get; set; }
    public List<int> PersonnelIds { get; set; }
}

public class CreateUserGroupCommandHandler : IRequestHandler<CreateUserGroupCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public CreateUserGroupCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext = null)
    {
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }
    public async Task<int> Handle(CreateUserGroupCommand request, CancellationToken cancellationToken)
    {
        var userGroup = _mapper.Map<UserGroup>(request);
        _applicationDbContext.UserGroups.Add(userGroup);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return userGroup.Id;
    }
}

