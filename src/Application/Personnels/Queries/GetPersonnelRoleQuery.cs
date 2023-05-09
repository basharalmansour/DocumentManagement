using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Personnels.Queries;
public class GetPersonnelRoleQuery : TableRequestModel, IRequest<TableResponseModel<Role>>
{
    public int PersonnelId { get; set; }
}
public class GetPersonnelRoleQueryHandler : BaseQueryHandler, IRequestHandler<GetPersonnelRoleQuery, TableResponseModel<Role>>
{

    public GetPersonnelRoleQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<TableResponseModel<Role>> Handle(GetPersonnelRoleQuery request, CancellationToken cancellationToken)
    {
        var result = _applicationDbContext.PersonnelRoles
            .Where(x => x.Id == request.PersonnelId);
        var selectedRoles=await  result
            .Select(x => x.Role)
            .ToListAsync();
        if (result == null)
            throw new Exception("Role or Personnel was NOT found");
        return new TableResponseModel<Role>(selectedRoles, request.PageNumber, request.PageSize, result.Count());
    }
}
