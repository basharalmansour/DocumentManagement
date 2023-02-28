using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.PresenceGroups;
public class PresenceGroup : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    public string Name { get; set; } 

}
