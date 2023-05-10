using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryQuery :TableRequestModel, IRequest<TableResponseModel<BasicServiceCategoryDto>>
{
    public string SearchText { get; set; }
}
public class GetServiceCategoryHandler : BaseQueryHandler, IRequestHandler<GetServiceCategoryQuery, TableResponseModel<BasicServiceCategoryDto>>
{

    public GetServiceCategoryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicServiceCategoryDto>> Handle(GetServiceCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = _applicationDbContext.ServiceCategories
            .Include(x => x.SubServiceCategories.Where(x => !x.IsDeleted))
            .Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText));
            
        var selectedCategories=await categories
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var categoriesDto = _mapper.Map<List<BasicServiceCategoryDto>>(selectedCategories);
        return new TableResponseModel<BasicServiceCategoryDto>(categoriesDto, request.PageNumber, request.PageSize, categories.Count());
    }
}
