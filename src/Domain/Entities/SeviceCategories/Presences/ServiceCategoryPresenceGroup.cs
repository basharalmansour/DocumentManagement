using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Presences;

public class ServiceCategoryPresenceGroup : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(ServiceCategory))]
    public int ServiceCategoryId { get; set; }
    public ServiceCategoryDetails ServiceCategory { get; set; }
    [ForeignKey(nameof(PresenceGroup))]
    public int PresenceGroupId { get; set; }
    public PresenceGroup PresenceGroup { get; set; }
}