using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Definitions.Vehicles;

namespace CleanArchitecture.Application.Common.Dtos.Vehicles;
public class VehicleDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<VehiclesDocumentDto> VehicleDocuments { get; set; }
    public List<VehicleDriverDocumentsDto> DriverDocuments { get; set; }
}
