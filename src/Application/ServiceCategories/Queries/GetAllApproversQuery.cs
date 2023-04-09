using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebUI.Controllers.ServiceCategories;

public class GetAllApproversQuery : IRequest<List<int>>
{
}
public class GetAllApproversQueryHandler : IRequestHandler<GetAllApproversQuery, List<int>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetAllApproversQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<int>> Handle(GetAllApproversQuery request, CancellationToken cancellationToken)
    {
        var result = await _applicationDbContext.PersonnelRules
            .Where(x => x.PersonRules.Contains(Rule.Approver))
            .Select(x=>x.PersonnelId)
            .ToListAsync();
        return result;
    }
}