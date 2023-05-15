using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Definitions.VehicleTemplates;
public class VehicleTemplate : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    public bool IsNeedDriver { get; set; }
    public List<VehicleTemplateDocument> VehicleTemplateDocuments { get; set; }
    public List<VehicleTemplateDriverDocument> DriverDocuments { get; set; }
}
