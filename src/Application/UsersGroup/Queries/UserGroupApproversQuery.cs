using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UsersGroup.Queries;
public class UserGroupApproversQuery : IRequest<List<UserGroupApproversDto>>
{
    public int Id { get; set; }
}

public class UserGroupApproversQueryHandler : BaseCommandQueryHandler, IRequestHandler<UserGroupApproversQuery, List<UserGroupApproversDto>>
{
    public UserGroupApproversQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }

    public async Task<List<UserGroupApproversDto>> Handle(UserGroupApproversQuery request, CancellationToken cancellationToken)
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
                    CategoryIds = approvers.Where(x => x.PersonnelId == id).Select(x => x.ServiceCategoryApprovment.ServiceCategory.Id).ToList(),
                    CategoryNames = approvers.Where(x => x.PersonnelId == id).Select(x => x.ServiceCategoryApprovment.ServiceCategory.Name).ToList(),
                    PersonnelId = id
                });
            }
        }
        return result;
    }
}