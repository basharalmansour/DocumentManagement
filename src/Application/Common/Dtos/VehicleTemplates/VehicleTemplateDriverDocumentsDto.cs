using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.VehicleTemplates;

public class VehicleTemplateDriverDocumentsDto
{
    public int DocumentTemplateId { get; set; }
    public int VehicleTemplateId { get; set; }
}