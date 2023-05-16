using CleanArchitecture.Domain.Entities.VehicleTemplates;
using CleanArchitecture.Domain.Entities.Vendors;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Vehicles;

public class VehicleDto
{
    public int Id { get; set; }
    public string PlateNumber { get; set; }
    public int VendorId { get; set; }
    public int VehicleTemplateId { get; set; }
}