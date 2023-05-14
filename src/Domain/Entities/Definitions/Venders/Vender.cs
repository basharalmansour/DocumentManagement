using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Definitions.Venders;
public class Vender : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.MediumString)]
    public string Name { get; set; }
    public List<VenderPersonnel> VenderPersonnels { get; set; }
}
