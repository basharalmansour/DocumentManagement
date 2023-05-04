using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Personnels.Queries;
public class GetPersonnelRoleQuery : IRequest<List<Role>>
{
    public int PersonnelId { get; set; }
}
public class GetPersonnelRoleQueryHandler : BaseQueryHandler, IRequestHandler<GetPersonnelRoleQuery, List<Role>>
{

    public GetPersonnelRoleQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<List<Role>> Handle(GetPersonnelRoleQuery request, CancellationToken cancellationToken)
    {
        var result= _applicationDbContext.PersonnelRoles.Where(x => x.Id == request.PersonnelId).Select(x => x.Role).ToList();
        return result;
    }
}
