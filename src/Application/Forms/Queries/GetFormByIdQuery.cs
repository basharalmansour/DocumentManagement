using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Forms.Queries;
public class GetFormByIdQuery : IRequest<FormDto>
{
    public int Id { get; set; }
}
public class GetFormByIdQueryHandler : IRequestHandler<GetFormByIdQuery, FormDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetFormByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<FormDto> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
    {
        var form =await _applicationDbContext.Forms.Include(x=>x.Questions).FirstOrDefaultAsync(x => x.Id == request.Id);
        var formDto = _mapper.Map<FormDto>(form);
        return formDto;
    }
}

