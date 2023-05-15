using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.VehicleTemplates;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
public class ServiceCategoryVehicleTemplate : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(VehicleTemplate))]
    public int VehicleTemplateId { get; set; }
    public VehicleTemplate VehicleTemplate { get; set; }

    [ForeignKey(nameof(ServiceCategory))]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; } 
    public List<ServiceCategoryVehicleTemplateDocument> VehicleTemplateDocuments { get; set; }
}
