using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Roles.Queries;
using CleanArchitecture.Domain.Entities.Definitions;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Rules.Command;
public class CreateRolesForPersonnelCommand : IRequest<bool>
{
    public Role Role { set; get; }
    public int PersonnelId { get; set; }
}
public class CreateRolesForPersonnelCommandHandler : BaseCommandQueryHandler, IRequestHandler<CreateRolesForPersonnelCommand, bool>
{

    public CreateRolesForPersonnelCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }
    public async Task<bool> Handle(CreateRolesForPersonnelCommand request, CancellationToken cancellationToken)
    {
        var personnelRole= _mapper.Map<PersonnelRoles>(request);
        _applicationDbContext.PersonnelRoles.Add(personnelRole);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
