using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class VehicleCategoryDto
{
    public int VehicleId { get; set; }
    public List<CategoryVehicleDocumentsDto> VehicleDocuments { get; set; }
}
