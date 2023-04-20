using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Roles.Queries;
public class GetPersonnelRoleQuery : IRequest<List<Role>>
{
    public int PersonnelId { get; set; }
}
public class GetPersonnelRoleQueryHandler : IRequestHandler<GetPersonnelRoleQuery, List<Role>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetPersonnelRoleQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<Role>> Handle(GetPersonnelRoleQuery request, CancellationToken cancellationToken)
    {
        var result= _applicationDbContext.PersonnelRoles.FirstOrDefault(x => x.Id == request.PersonnelId).PersonRoles.Select(x => x.Role).ToList();
        return result;
    }
}
