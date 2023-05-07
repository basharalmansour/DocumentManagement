using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Definitions.Roles;
public class PersonnelRole : LightBaseEntity<int>, IEntity<int>
{
    public Role Role { set; get; }
    public int PersonnelId { get; set; }
}
