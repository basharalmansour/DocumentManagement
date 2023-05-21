using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Orders.Commands;
//TODO: is the approvment mechanism should be handled here?
public class ChangeOrderStatusCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public OrderStatus NewOrderStatus { get; set; }
}
public class ChangeOrderStatusCommandHandler : BaseCommandHandler, IRequestHandler<ChangeOrderStatusCommand, Guid>
{
    public ChangeOrderStatusCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<Guid> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
    {
        // create service for changing status
        switch (request.NewOrderStatus)
        {
            case OrderStatus.Approved: 
                return Guid.Empty;
            case OrderStatus.InProcess: 
                return Guid.Empty;
            case OrderStatus.Cancelled: 
                return Guid.Empty;
            case OrderStatus.Done: 
                return Guid.Empty;
        }
        return Guid.Empty;
    }
}
