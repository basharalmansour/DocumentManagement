using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class ServiceCategoryByIdQuery : IRequest<GetServiceCategoryDto>
{
    public int Id { get; set; }
}
public class ServiceCategoryByIdQueryHandler : IRequestHandler<ServiceCategoryByIdQuery, GetServiceCategoryDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public ServiceCategoryByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<GetServiceCategoryDto> Handle(ServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _applicationDbContext.ServiceCategories.Include(x => x.SubServiceCategories).FirstOrDefaultAsync(x=>x.Id==request.Id);
        var categoryDto = _mapper.Map<GetServiceCategoryDto>(category);
        return categoryDto;
    }
}
