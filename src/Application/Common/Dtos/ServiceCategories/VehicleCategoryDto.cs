using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class VehicleCategoryDto
{
    public int VehicleTemplateId { get; set; }
    public List<CategoryVehicleDocumentsDto> VehicleTemplateDocuments { get; set; }
}
