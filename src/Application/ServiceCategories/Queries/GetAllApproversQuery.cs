using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebUI.Controllers.ServiceCategories;

public class GetAllApproversQuery : IRequest<List<int>>
{
}
public class GetAllApproversQueryHandler : BaseCommandQueryHandler, IRequestHandler<GetAllApproversQuery, List<int>>
{

    public GetAllApproversQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {

    }
    public async Task<List<int>> Handle(GetAllApproversQuery request, CancellationToken cancellationToken)
    {
        var result = await _applicationDbContext.PersonnelRoles
            .Where(x => x.Role==Role.Approver)
            .Select(x=>x.PersonnelId)
            .ToListAsync();
        return result;
    }
}