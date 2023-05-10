using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UsersGroup.Queries;
public class GetUserGroupApproversQuery : TableRequestModel, IRequest<TableResponseModel<UserGroupApproversDto>>
{
    public int Id { get; set; }
}

public class GetUserGroupApproversQueryHandler : BaseQueryHandler, IRequestHandler<GetUserGroupApproversQuery, TableResponseModel<UserGroupApproversDto>>
{
    public GetUserGroupApproversQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }

    public async Task<TableResponseModel<UserGroupApproversDto>> Handle(GetUserGroupApproversQuery request, CancellationToken cancellationToken)
    {
        List<UserGroupApproversDto> result = new List<UserGroupApproversDto>();
        var personnelsIds = _applicationDbContext.UserGroups
            .FirstOrDefault(x => x.Id == request.Id)
            .Personnels
            .Select(x=>x.PersonnelId)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
        
        var approvers =await _applicationDbContext.ResponsiblePersonnels
            .Include(x => x.ServiceCategoryRole.ServiceCategory)
            .Where(x=> personnelsIds.Contains(x.PersonnelId))
            .GroupBy(x=>x.PersonnelId)
            .ToListAsync();
       
        foreach (var approver in approvers)
        {
            result.Add(new UserGroupApproversDto
            {
                ServiceCategories =_mapper.Map<List<BasicServiceCategoryDto>>(approver.Select(x=>x.ServiceCategoryRole.ServiceCategory)),
                PersonnelId = approver.Key
            });
        }
        return new TableResponseModel<UserGroupApproversDto>(result, request.PageNumber, request.PageSize, approvers.Count());
    }
}