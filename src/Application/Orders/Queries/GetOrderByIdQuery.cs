using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Orders;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Orders.Queries;
public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public Guid OrderId { get; set; }
}
public class GetOrderByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetOrderByIdQuery, OrderDto>
{

    public GetOrderByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }
    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order =await _applicationDbContext.Orders
            .Include(x=>x.AdditionalParameters)
            .Include(x=>x.Vendor)
            .Include(x=>x.ServiceCategory)
            .Include(x=>x.Documents).ThenInclude(x=>x.ServiceCategoryDocument).ThenInclude(x=>x.DocumentTemplate)
            .Include(x=>x.Equipments)
            .Include(x=>x.Personnels).ThenInclude(x=>x.Documents)
            .Include(x=>x.Vehicles).ThenInclude(x=>x.Documents)
            .Include(x => x.Vehicles).ThenInclude(x => x.Drivers).ThenInclude(x=>x.Documents)
            .FirstOrDefaultAsync(x => x.Id == request.OrderId);
        if (order == null)
            throw new Exception("Order was NOT found");
        var orderDto = _mapper.Map<OrderDto>(order);
        return orderDto;
    }
}