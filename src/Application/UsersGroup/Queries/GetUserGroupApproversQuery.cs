using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UsersGroup.Queries;
public class GetUserGroupApproversQuery : IRequest<List<UserGroupApproversDto>>
{
    public int Id { get; set; }
}

public class GetUserGroupApproversQueryHandler : BaseCommandQueryHandler, IRequestHandler<GetUserGroupApproversQuery, List<UserGroupApproversDto>>
{
    public GetUserGroupApproversQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }

    public async Task<List<UserGroupApproversDto>> Handle(GetUserGroupApproversQuery request, CancellationToken cancellationToken)
    {
        List<UserGroupApproversDto> result = new List<UserGroupApproversDto>();
        var personnelsIds = _applicationDbContext.UserGroups.FirstOrDefault(x => x.Id == request.Id).Personnels.Select(x=>x.PersonnelId).ToList();
        var approvers =await _applicationDbContext.ApproverPersonnels.ToListAsync();
        var approversPersonnel = approvers.Select(x => x.PersonnelId);

        foreach (int id in personnelsIds)
        {
            if(approversPersonnel.Contains(id))
            {
                result.Add(new UserGroupApproversDto
                {
                    ServiceCategories =_mapper.Map<List<BasicServiceCategoryDto>>(approvers.Select(x=>x.ServiceCategoryRole.ServiceCategory).ToList()),
                    PersonnelId = id
                });
            }
        }
        return result;
    }
}