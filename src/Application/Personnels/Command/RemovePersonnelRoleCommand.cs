using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Personnels.Command;
public class RemovePersonnelRoleCommand : IRequest<bool>
{
    public Role Role { set; get; }
    public int PersonnelId { get; set; }
}
public class RemovePersonnelRoleCommandHandler : BaseCommandHandler, IRequestHandler<RemovePersonnelRoleCommand, bool>
{

    public RemovePersonnelRoleCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {

    }
    public async Task<bool> Handle(RemovePersonnelRoleCommand request, CancellationToken cancellationToken)
    {
        var role =await  _applicationDbContext.PersonnelRoles.FirstOrDefaultAsync(x => x.PersonnelId == request.PersonnelId && x.Role == request.Role);
        _applicationDbContext.PersonnelRoles.Remove(role);
        return true;
    }
}