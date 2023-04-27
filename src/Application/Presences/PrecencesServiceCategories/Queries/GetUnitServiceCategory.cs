﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PrecencesServiceCategories.Queries;
public  class GetUnitServiceCategory : IRequest<List<BasicServiceCategoryDto>>
{
    public int  UnitId { get; set; }
}
public class GetUnitServiceCategoryHandler : BaseCommandQueryHandler, IRequestHandler<GetUnitServiceCategory, List<BasicServiceCategoryDto>>
{
    public GetUnitServiceCategoryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<List<BasicServiceCategoryDto>> Handle(GetUnitServiceCategory request, CancellationToken cancellationToken)
    {
        var serviceCategories = await _applicationDbContext.ServiceCategoryUnits.Where(x => x.UnitId == request.UnitId).Select(x => x.ServiceCategory).ToListAsync();
        var result = _mapper.Map<List<BasicServiceCategoryDto>>(serviceCategories);
        return result;
    }
}