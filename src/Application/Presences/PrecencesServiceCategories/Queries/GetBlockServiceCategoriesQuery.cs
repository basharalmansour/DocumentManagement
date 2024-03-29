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
public  class GetBlockServiceCategoriesQuery : TableRequestModel, IRequest<TableResponseModel<BasicServiceCategoryDto>>
{
    public Guid BlockId { get; set; }
}
public class GetBlockServiceCategoriesHandler : BaseQueryHandler, IRequestHandler<GetBlockServiceCategoriesQuery, TableResponseModel<BasicServiceCategoryDto>>
{
    public GetBlockServiceCategoriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicServiceCategoryDto>> Handle(GetBlockServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var serviceCategories = _applicationDbContext.ServiceCategoryBlocks
            .Include(x => x.ServiceCategory)
            .Where(x => x.BlockId == request.BlockId);
        var selectedCategories = await serviceCategories
            .Select(x => x.ServiceCategory)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(selectedCategories);
        return new TableResponseModel<BasicServiceCategoryDto>(result, request.PageNumber, request.PageSize, serviceCategories.Count());
    }
}
