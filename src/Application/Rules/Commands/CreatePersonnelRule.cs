using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.PresenceGroups.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Rules.Commands;
public  class CreatePersonnelRule : IRequest<bool>
{
    public string Name { get; set; }
    public List<Rule> PersonRules { get; set; }
    public int PersonnelId { get; set; }
}
public class CreatePersonnelRuleHandler : IRequestHandler<CreatePersonnelRule, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public CreatePersonnelRuleHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreatePersonnelRule request, CancellationToken cancellationToken)
    {
        var result= _mapper.Map<PersonnelRules>(request);
        _applicationDbContext.PersonnelRules.Add(result);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
