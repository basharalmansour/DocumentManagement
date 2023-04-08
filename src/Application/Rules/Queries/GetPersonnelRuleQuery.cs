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

namespace CleanArchitecture.Application.Rules.Queries;
public class GetPersonnelRuleQuery : IRequest<List<Rule>>
{
    public int PersonnelId { get; set; }
}
public class GetPersonnelRuleQueryHandler : IRequestHandler<GetPersonnelRuleQuery, List<Rule>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetPersonnelRuleQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<Rule>> Handle(GetPersonnelRuleQuery request, CancellationToken cancellationToken)
    {
        var result=await _applicationDbContext.PersonnelRules.FirstOrDefaultAsync(x => x.Id == request.PersonnelId);
        return result.PersonRules;
    }
}
