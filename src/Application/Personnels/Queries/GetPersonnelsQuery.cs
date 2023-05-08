using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Personnels.Queries;

public class GetPersonnelsQuery : IRequest<List<GetPersonnelDetailsDto>>
{
    public List<Role> Roles { get; set; }
    public string SearchText { get; set; }
    public int DepartmentId { get; set; }
}
public class GetPersonnelsQueryHandler : BaseQueryHandler, IRequestHandler<GetPersonnelsQuery, List<GetPersonnelDetailsDto>>
{

    public GetPersonnelsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<List<GetPersonnelDetailsDto>> Handle(GetPersonnelsQuery request, CancellationToken cancellationToken)
    {
        if (request.Roles == null)
            request.Roles= new List<Role> { Role.Approver , Role.Observer ,Role.Reporter , Role.Canceler};
        var result = await _applicationDbContext.PersonnelRoles
             .Where(x =>request.Roles.Contains(x.Role))
             .Select(x =>new GetPersonnelDetailsDto { PersonnelId = x.PersonnelId })
             .Distinct()
             .ToListAsync();
        return result;
        
    }
}