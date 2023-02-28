using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
public class ServiceCategoryCompany
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Presence")]
    public int PresenceId { get; set; }
    public Presence Presence { get; set; }
    public int CompanyId { get; set; }
}
