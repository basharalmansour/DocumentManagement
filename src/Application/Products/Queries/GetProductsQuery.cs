using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Products;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Products.Queries;



public class ProductService
{
    public List<GetProductsDto> GetProducts(string searchWord)
    {
        var integrationName = Enum.GetName(request.IntegrationType.GetType(), request.IntegrationType);
        var siteIntegration = await _applicationDbContext.SiteIntegrations
                        .Include(x => x.Integration)
                        .ThenInclude(x => x.Products)
                        .Where(x => x.SiteId == _currentUserService.SiteId && x.Integration.IntegrationType == request.IntegrationType)
                        .FirstOrDefaultAsync(cancellationToken);

        var result = _mapper.Map<List<GetProductsDto>>(siteIntegration?.Integration.Products);
        return result;
    }

}




public class GetProductsQuery : IRequest<List<GetProductsDto>>
{
    public string SearchWord { get; set; }

}

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    public GetProductsQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<List<GetProductsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var integrationName = Enum.GetName(request.IntegrationType.GetType(), request.IntegrationType);
        var siteIntegration = await _applicationDbContext.SiteIntegrations
                        .Include(x => x.Integration)
                        .ThenInclude(x => x.Products)
                        .Where(x => x.SiteId == _currentUserService.SiteId && x.Integration.IntegrationType == request.IntegrationType)
                        .FirstOrDefaultAsync(cancellationToken);
           
        var result = _mapper.Map<List<GetProductsDto>>(siteIntegration?.Integration.Products);
        return result;
    }
}



public class NameOfFunctionQuery : IRequest<ReturnType>
{
    public string parameteres { get; set; }

}
public class NameOfFunctionHandler : IRequestHandler<NameOfFunctionQuery, ReturnType>
{
    private readonly IApplicationDbContext _applicationDbContext;
    public NameOfFunctionHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<ReturnType> Handle(NameOfFunctionQuery request, CancellationToken cancellationToken)
    {
        //write your code
        return result;
    }
}