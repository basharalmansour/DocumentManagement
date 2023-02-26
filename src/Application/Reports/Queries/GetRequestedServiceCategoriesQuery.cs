using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.Report;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Reports.Queries;

public class GetRequestedServiceCategoriesQuery : IRequest<ReportResultDto>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestIntegrationType IntegrationType { get; set; }
}
public class GetRequestedServiceCategoriesQueryHandler : IRequestHandler<GetRequestedServiceCategoriesQuery, ReportResultDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly ICurrentUserService _currentUserService;
    
    public GetRequestedServiceCategoriesQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
    {
        _applicationDbContext = applicationDbContext;
        _currentUserService = currentUserService;
    }

    public async Task<ReportResultDto> Handle(GetRequestedServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var products = _applicationDbContext.SiteIntegrations
                        .Include(x => x.Integration)
                        .ThenInclude(x => x.Products)
                        .Where(x => x.SiteId == _currentUserService.SiteId && x.Integration.Name.Contains("TAV"))
                        .AsEnumerable()
                        .SelectMany(x => x.Integration.Products);
        var orders = (from product in products
                      join order in _applicationDbContext.Orders
                      on product.Id equals order.ProductId into ProductOrders
                      where ProductOrders.Any()
                      select new ReportSerie()
                      {
                          Name = product.Name,
                          Value = ProductOrders.Count(x=>x.CreatedDate>= request.StartDate && x.CreatedDate<= request.EndDate)
                      }).ToList();
        var result = new ReportResultDto()
        {
            Entries = new List<ReportEntry>()
             {
                new ReportEntry()
                {
                     Name = "Talep edilen hizmet",
                     Series = orders,
                }
             }
        };
        return result;
    }
}


