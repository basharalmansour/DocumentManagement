using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Definitions.Venders;
public class VenderPersonnel : LightBaseEntity<int> , IEntity<int>
{
    [ForeignKey("Vender")]
    public int VenderId { get; set; }
    public Vender Vender { get; set; }
    public int PersonnelId { get; set; }
    public string PersonnelName { get; set; }
}
