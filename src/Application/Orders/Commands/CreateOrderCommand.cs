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
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Application.Common.Dtos.Orders;

namespace CleanArchitecture.Application.Orders.Commands;
public class CreateOrderCommand : IRequest<Guid>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public int VendorId { get; set; }
    public int ServiceCategoryId { get; set; }
    public int? IntegerPresenceId { get; set; }
    public Guid? GuidPresenceId { get; set; }
    public PresencesType PresencesType { get; set; }
    public List<int> Equipments { get; set; }
    public CreateOrderEquipmentDto NewEquipment { get; set; }
    public List<CreateOrderDocumentDto> Documents { get; set; }
    public List<int> Personnels { get; set; }
    public List<CreateOrderVehicleDto> Vehicles { get; set; }
}
public class CreateOrderCommandHandler : BaseCommandHandler, IRequestHandler<CreateOrderCommand, Guid>
{
    public CreateOrderCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        /*
         * 1- validate start date and end date : 
         *         *start date < end date (fluent validation)
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
         * 2- add documents and get its Ids (FileManager.Create())
         * 
         * THEN 
         * 
         * Map the dto to object
         * 
         * THEN
         * 
         * Add additional parameters
         */
        ValidateOrder();
        AddNewRecords();
        //map the order
        //set order status
        AddAdditionalParameters();

        return Guid.Empty;
    }

    private void AddAdditionalParameters()
    {

    }

    private void AddNewRecords()
    {

    }
    
    private void ValidateOrder()
    {

    }
}
