using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
public class PresenceGroup : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.MediumString)]
    public string Name { get; set; }
    public List<PresenceGroupArea> PresenceGroupAreas { get; set; }
    public List<PresenceGroupBlock> PresenceGroupBlocks { get; set; }
    public List<PresenceGroupBrand> PresenceGroupBrands { get; set; }
    public List<PresenceGroupSite > PresenceGroupSites { get; set; }
    public List<PresenceGroupUnit > PresenceGroupUnits { get; set; }
    public List<PresenceGroupZone > PresenceGroupZones { get; set; }
}
