using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Presences;

public class ServiceCategoryPresenceGroup
{
    [ForeignKey("ServiceCategory")]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    [ForeignKey("PresenceGroup")]
    public int PresenceGroupId { get; set; }
    public PresenceGroup PresenceGroup { get; set; }
}