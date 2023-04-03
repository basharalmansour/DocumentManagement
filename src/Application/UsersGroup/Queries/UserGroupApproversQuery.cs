using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UsersGroup.Queries;
public class UserGroupApproversQuery : IRequest<List<UserGroupApproversDto>>
{
    public int Id { get; set; }
}

public class UserGroupApproversQueryHandler : IRequestHandler<UserGroupApproversQuery, List<UserGroupApproversDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public UserGroupApproversQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<List<UserGroupApproversDto>> Handle(UserGroupApproversQuery request, CancellationToken cancellationToken)
    {
        List<UserGroupApproversDto> result = new List<UserGroupApproversDto>();
        var personnelsIds = _applicationDbContext.UserGroups.FirstOrDefault(x => x.Id == request.Id).Personnels.Select(x=>x.PersonnelId).ToList();
        var approvers =await _applicationDbContext.ApproverPersonnels.ToArrayAsync();
        int categoryId;
        string categoryName;
        foreach (int id in personnelsIds)
        {
            if (approvers.Select(x => x.PersonnelId).Contains(id))
            {
                categoryId = approvers.FirstOrDefault(x => x.PersonnelId == id).ServiceCategoryApprovmentId;
                categoryName = _applicationDbContext.ServiceCategories.FirstOrDefault(x => x.Id == categoryId).Name;
                result.Add(new UserGroupApproversDto
                {
                    CategoryId = categoryId,
                    CategoryName = categoryName,
                    PersonnelId = id,
                });
            }
        }
        return result;
    }
}