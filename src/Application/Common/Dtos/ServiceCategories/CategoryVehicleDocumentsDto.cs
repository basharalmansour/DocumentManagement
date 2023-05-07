using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using CleanArchitecture.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class CategoryVehicleDocumentsDto
{
    public int VehicleCategoryId { get; set; }
    public int DocumentTemplateId { get; set; }
    public bool IsRequired { get; set; }
    public VehicleDocumentType VehicleDocumentType { get; set; }
}