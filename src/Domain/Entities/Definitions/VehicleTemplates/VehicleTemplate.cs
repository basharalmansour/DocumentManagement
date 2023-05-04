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
    [StringLength(StringLengths.MediumString)]
    public string Name { get; set; }
    public bool IsNeedDriver { get; set; }
    public List<VehicleTemplatesDocument> VehicleTemplateDocuments { get; set; }
    public List<VehicleTemplateDriverDocuments> DriverDocuments { get; set; }
}
