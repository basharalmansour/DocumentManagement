using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Vehicles;

public class VehiclesDocumentDto
{
    public int DocumentTemplateId { get; set; }
    public int VehicleId { get; set; }
}