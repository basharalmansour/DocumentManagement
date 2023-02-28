using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
public class VehicleCategory
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Vehicle")]
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public ServiceCategory Category  { get; set; } 
}
