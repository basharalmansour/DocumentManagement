using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Forms;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Orders.Commands;
public class CreateOrderCommand : IRequest<int>
{
}
public class CreateOrderCommandHandler : BaseCommandHandler, IRequestHandler<CreateOrderCommand, int>
{
    public CreateOrderCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        /*
         * 1- validate start date and end date : 
         *         *start date < end date
         *         *duration < service category max duration
         *         
         * 
         * 3- validate documents (service category, personnel, vehicle, driver): 
         *         * if service category has required documents which not added
         *         * if added documents type is accepted
         *         
         * 4- validate personnels : 
         *         * if selected personnels count <= max service category personnel count
         *         
         * THEN
         * 
         * before adding order : 
         * 1- check if selected equipments has new equipment, if yes then add the equipment before adding the order
         * 2- add documents and get its Ids
         */
    }
}
