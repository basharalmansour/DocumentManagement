using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Definitions.Vehicles;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
public class VehicleCategory : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("Vehicle")]
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }

    [ForeignKey("ServiceCategory")]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; } 
}
