using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Forms.Queries;
public class GetFormsQuery : IRequest<List<BasicFormDto>>
{
}
public class GetFormsQueryHandler : IRequestHandler<GetFormsQuery, List<BasicFormDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetFormsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<BasicFormDto>> Handle(GetFormsQuery request, CancellationToken cancellationToken)
    {
        var forms =await  _applicationDbContext.Forms
            .Include(x => x.Questions)
            .Where(x=> !x.IsDeleted)
            .ToListAsync();
        var formsDto = _mapper.Map<List<BasicFormDto>>(forms);
        return formsDto;
    }
}
