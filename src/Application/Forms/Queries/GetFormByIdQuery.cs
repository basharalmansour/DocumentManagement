using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Forms.Queries;
public class GetFormByIdQuery : IRequest<FormDto>
{
    public int Id { get; set; }
}
public class GetFormByIdQueryHandler : BaseCommandQueryHandler, IRequestHandler<GetFormByIdQuery, FormDto>
{

    public GetFormByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(mapper, applicationDbContext)
    {
    }
    public async Task<FormDto> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
    {
        var form =await _applicationDbContext.Forms
            .Include(x=>x.Questions)
            .ThenInclude(x=>x.MultiChoicesQuestions)
            .Include(x => x.Questions)
            .ThenInclude(x => x.DateQuestionOptions)
            .Include(x => x.Questions)
            .ThenInclude(x => x.FileQuestionOptions)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        var formDto = _mapper.Map<FormDto>(form);
        return formDto;
    }
}

