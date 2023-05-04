using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Documents;

namespace CleanArchitecture.Domain.Entities.Definitions.VehicleTemplates;
public class VehicleTemplatesDocument : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("DocumentTemplate")]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    [ForeignKey("VehicleTemplate")]
    public int VehicleTemplateId { get; set; }
    public VehicleTemplate VehicleTemplate  { get; set; }
}
