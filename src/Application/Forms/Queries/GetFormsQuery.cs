using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Forms.Queries;
public class GetFormsQuery : TableRequestModel, IRequest<TableResponseModel<BasicFormDto>>
{

}
public class GetFormsQueryHandler : BaseQueryHandler, IRequestHandler<GetFormsQuery, TableResponseModel<BasicFormDto>>
{
    public GetFormsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicFormDto>> Handle(GetFormsQuery request, CancellationToken cancellationToken)
    {
        var forms = _applicationDbContext.Forms
            .Include(x => x.Questions)
            .Where(x => !x.IsDeleted);

        var selectedForms = await forms
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var formsDto = _mapper.Map<List<BasicFormDto>>(selectedForms);
        return new TableResponseModel<BasicFormDto>(formsDto, request.PageNumber, request.PageSize, forms.Count());
    }
}
