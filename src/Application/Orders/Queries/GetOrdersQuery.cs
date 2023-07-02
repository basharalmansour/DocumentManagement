using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Orders;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Domain.Enums;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Orders.Queries;
public class GetOrdersQuery : TableRequestModel, IRequest<TableResponseModel<BasicOrderDto>>
{
    public string SearchText { get; set; }
    public PresencesType? PresencesType { get; set; }
    public int? PresenceIntegerId { get; set; }
    public Guid? PrsenceGuidId { get; set; }
    public int? VendorId { get; set; }
    public int? ServiceCategoryId { get; set; }
    public string UserId { get; set; }
}
public class GetOrdersQueryHandler : BaseQueryHandler, IRequestHandler<GetOrdersQuery, TableResponseModel<BasicOrderDto>>
{

    public GetOrdersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicOrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Order>();
        predicate = predicate.And(x => !x.IsDeleted);
        if (!string.IsNullOrEmpty(request.SearchText))
            predicate = predicate.And(x => x.Description.ToLower().Contains(request.SearchText.ToLower()));
        if (request.VendorId != null)
            predicate = predicate.And(x => x.VendorId == request.VendorId);
        if (request.UserId != null)
            predicate = predicate.And(x => x.UserId == request.UserId);
        if (request.ServiceCategoryId != null)
            predicate = predicate.And(x => x.ServiceCategoryId == request.ServiceCategoryId);
        if (request.PresencesType != null)
            predicate = predicate.And(x => x.PresencesType == request.PresencesType);
        if (request.PresenceIntegerId != null)
            predicate = predicate.And(x => x.IntegerPresenceId == request.PresenceIntegerId);
        if (request.PrsenceGuidId != null)
            predicate = predicate.And(x => x.GuidPresenceId == request.PrsenceGuidId);

        var orders = _applicationDbContext.Orders
            .Where(predicate);

        var selectedCategories = await orders
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var ordersDto = _mapper.Map<List<BasicOrderDto>>(selectedCategories);
        return new TableResponseModel<BasicOrderDto>(ordersDto, request.PageNumber, request.PageSize, orders.Count());
    }
}