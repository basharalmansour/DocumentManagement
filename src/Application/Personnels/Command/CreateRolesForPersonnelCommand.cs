using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Personnels.Queries;
using CleanArchitecture.Domain.Entities.Definitions.Roles;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Personnels.Command;
public class CreateRolesForPersonnelCommand : IRequest<bool>
{
    public Role Role { set; get; }
    public int PersonnelId { get; set; }
}
public class CreateRolesForPersonnelCommandHandler : BaseCommandHandler, IRequestHandler<CreateRolesForPersonnelCommand, bool>
{

    public CreateRolesForPersonnelCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<bool> Handle(CreateRolesForPersonnelCommand request, CancellationToken cancellationToken)
    {
        var personnelRole= _mapper.Map<PersonnelRole>(request);
        _applicationDbContext.PersonnelRoles.Add(personnelRole);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
