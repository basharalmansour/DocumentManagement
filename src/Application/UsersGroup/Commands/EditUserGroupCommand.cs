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
public class EditUserGroupCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> PersonnelIds { get; set; }
    public string UniqueCode { get; set; }
}

public class EditUserGroupCommandHandler : IRequestHandler<EditUserGroupCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public EditUserGroupCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext = null)
    {
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }
    public async Task<bool> Handle(EditUserGroupCommand request, CancellationToken cancellationToken)
    {
        var userGroup = _applicationDbContext.UserGroups.FirstOrDefault(x => x.Id == request.Id);
        _mapper.Map(userGroup , request);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
