using System;
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

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetMaxPersonnelCountQuery : IRequest<int>
{
    public int ServiceCategoryId { get; set; }
}
public class GetMaxPersonnelCountHandler : BaseQueryHandler, IRequestHandler<GetMaxPersonnelCountQuery, int>
{
    public GetMaxPersonnelCountHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<int> Handle(GetMaxPersonnelCountQuery request, CancellationToken cancellationToken)
    {
        var category = await _applicationDbContext.ServiceCategoryDetails.FirstOrDefaultAsync(x => x.Id == request.ServiceCategoryId);
        return category.MaxPersonnelCount;
    }
}