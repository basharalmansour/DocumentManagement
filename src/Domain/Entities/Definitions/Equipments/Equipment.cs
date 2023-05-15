using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using MongoDB.Bson;

namespace CleanArchitecture.Domain.Entities.Definitions.Equipments;
public class Equipment : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    public bool IsNoise { get; set; }
    public bool IsHeat { get; set; }
    public bool IsHidden { get; set; }
}
