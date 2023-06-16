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
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Entities.Definitions.Equipments;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Orders;
using LinqKit;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Application.Common.Dtos.Orders.CreateDtos;

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
    public List<CreateOrderPersonnelDto> Personnels { get; set; }
    public List<CreateOrderVehicleDto> Vehicles { get; set; }
}
public class CreateOrderCommandHandler : BaseCommandHandler, IRequestHandler<CreateOrderCommand, Guid>
{
    public CreateOrderCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        ValidateOrder(request);
        AddNewRecords(request);

        var newOrder = _mapper.Map<Order>(request);
        newOrder.OrderStatus = OrderStatus.WaitingApprove;
        newOrder.UniqueCode = UniqueCode.CreateUniqueCode(10,true, "O");
        AddAdditionalParameters();
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return newOrder.Id;
    }

    private void AddNewRecords(CreateOrderCommand request)
    {
        if (request.NewEquipment != null)
        {
            var equipment = _mapper.Map<Equipment>(request.NewEquipment);
            equipment.IsHidden = true;
            _applicationDbContext.Equipments.Add(equipment);
            _applicationDbContext.SaveChanges();
            request.Equipments.Add(equipment.Id);
        }

        foreach (var document in request.Documents)
        {
            var filePath = FileManager.Create(document.File);
            document.FilePath = filePath;
            document.FileStatus = FileStatus.New;
        }

    }

    private void ValidateOrder(CreateOrderCommand request)
    {
        var serviceCategory = _applicationDbContext.ServiceCategories
            .Include(x => x.ServiceCategoryDetails.Documents)
            .ThenInclude(x=>x.DocumentTemplate.DocumentTemplateFileTypes)
            .FirstOrDefault(x => x.Id == request.ServiceCategoryId)
            .ServiceCategoryDetails;

        var serviceCategoryDuration = TimeUnitsConverter.ConvertToMinutes(serviceCategory.MaxServiceDuration, serviceCategory.ServiceDurationUnit);
        var selectedDuration = request.EndDate - request.StartDate;
        if (selectedDuration.Minutes > serviceCategoryDuration)
            throw new Exception("This service has maximum duration " + serviceCategory.MaxServiceDuration + serviceCategory.ServiceDurationUnit + "to be completed");

        if (serviceCategory.MaxPersonnelCount < request.Personnels.Count)
            throw new Exception("The maximum number of personnel for this service is: " + serviceCategory.MaxPersonnelCount);

        var vehiclesDocuments = _applicationDbContext.ServiceCategoryVehicleTemplateDocuments
            .Include(x => x.ServiceCategoryVehicleTemplate)
            .Where(x => x.ServiceCategoryVehicleTemplate.ServiceCategoryId == request.ServiceCategoryId)
            .ToList();
        ValidateDocuments(serviceCategory.Documents , request.Documents);
        ValidateDocuments(vehiclesDocuments.Where(x => x.VehicleDocumentType == VehicleDocumentType.Vehicle).ToList() , request.Vehicles.SelectMany(x=>x.Documents).ToList());
        ValidateDocuments(serviceCategory.PersonnelDocuments, request.Personnels.SelectMany(x=>x.Documents).ToList());
        ValidateDocuments(vehiclesDocuments.Where(x=>x.VehicleDocumentType==VehicleDocumentType.Driver).ToList(), request.Vehicles.SelectMany(x=>x.Drivers).SelectMany(x=>x.Documents).ToList());
    }

    private void ValidateDocuments<T> (List<T> documents , List<CreateOrderDocumentDto> requestDocuments ) where T:IDocumentContent 
    {
        foreach (var document in documents)
        {
            if (document.IsRequired)
                if (!requestDocuments.Select(x => x.DocumentId).Contains(document.DocumentTemplateId))
                    throw new Exception("Document" + document.DocumentTemplate.Name + "is missing");
            var acceptedTypes = document.DocumentTemplate.DocumentTemplateFileTypes.Select(x => x.FileType).ToList();
            var acceptedTypesAsString = DocumentFileExtension.ConvertToString(acceptedTypes);
            var selectedDocumentName = requestDocuments.FirstOrDefault(x => x.DocumentId == document.DocumentTemplateId).File.FileName;
            if (!acceptedTypesAsString.Contains(Path.GetExtension(selectedDocumentName)))
                throw new Exception("Invalid document type");
        }
    }

    private void AddAdditionalParameters()
    {

    }

}
