using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
public class VehicleTemplateDto: BasicVehicleTemplateDto
{
    public List<VehicleTemplatesDocumentDto> VehicleDocuments { get; set; }
    public List<VehicleTemplateDriverDocumentsDto> DriverDocuments { get; set; }
}
