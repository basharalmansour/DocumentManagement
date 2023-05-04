using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.VehicleTemplates;

public class VehicleTemplatesDocumentDto
{
    public int DocumentTemplateId { get; set; }
    public int VehicleTemplateId { get; set; }
}