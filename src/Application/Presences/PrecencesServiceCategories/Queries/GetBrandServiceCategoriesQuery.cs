﻿using System;
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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PrecencesServiceCategories.Queries;
public  class GetBrandServiceCategoriesQuery : TableRequestModel, IRequest<TableResponseModel<BasicServiceCategoryDto>>
{
    public int BrandId { get; set; }
}
public class GetBrandServiceCategoriesHandler : BaseQueryHandler, IRequestHandler<GetBrandServiceCategoriesQuery, TableResponseModel<BasicServiceCategoryDto>>
{
    public GetBrandServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicServiceCategoryDto>> Handle(GetBrandServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var serviceCategories = _applicationDbContext.ServiceCategoryBrands
            .Include(x => x.ServiceCategory)
            .Where(x => x.BrandId == request.BrandId);
        var selectedCategories = await serviceCategories
            .Select(x => x.ServiceCategory)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(selectedCategories);
        return new TableResponseModel<BasicServiceCategoryDto>(result, request.PageNumber, request.PageSize, serviceCategories.Count());
    }
}
