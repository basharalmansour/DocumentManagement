using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Orders;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Orders.Commands;
public class EditOrderCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public List<int> Personnels { get; set; }
    public List<CreateOrderVehicleDto> Vehicles { get; set; }
}
public class EditOrderCommandHandler : BaseCommandHandler, IRequestHandler<EditOrderCommand, Guid>
{
    public EditOrderCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<Guid> Handle(EditOrderCommand request, CancellationToken cancellationToken)
    {
        return Guid.Empty;
    }
}
