using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Personnels.Queries;

public class GetPersonnelsQuery : TableRequestModel, IRequest<TableResponseModel<GetPersonnelDetailsDto>>
{
    public List<Role> Roles { get; set; }
    public string SearchText { get; set; }
    public int DepartmentId { get; set; }
}
public class GetPersonnelsQueryHandler : BaseQueryHandler, IRequestHandler<GetPersonnelsQuery, TableResponseModel<GetPersonnelDetailsDto>>
{

    public GetPersonnelsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<TableResponseModel<GetPersonnelDetailsDto>> Handle(GetPersonnelsQuery request, CancellationToken cancellationToken)
    {
        if (request.Roles == null)
            request.Roles= new List<Role> { Role.Approver , Role.Observer ,Role.Reporter , Role.Canceler};

        var result = _applicationDbContext.PersonnelRoles
             .Where(x => request.Roles.Contains(x.Role));

        var selectedPersonnels = await result
            .Select(x => new GetPersonnelDetailsDto { PersonnelId = x.PersonnelId })
            .Distinct()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new TableResponseModel<GetPersonnelDetailsDto>(selectedPersonnels, request.PageNumber, request.PageSize, result.Count());
    }
}