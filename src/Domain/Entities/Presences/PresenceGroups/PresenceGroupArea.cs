using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
public class PresenceGroupArea : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("PresenceGroup")]
    public int PresenceGroupId { get; set; }
    public PresenceGroup PresenceGroup { get; set; }
    public int AreaId { get; set; }
}
