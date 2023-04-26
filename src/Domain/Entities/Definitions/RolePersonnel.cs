using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Definitions;
public  class RolePersonnel : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("PersonnelRoles")]
    public int PersonnelRolesId { set; get; }
    public PersonnelRoles PersonnelRoles { set; get; }
    public Role Role { set; get; }
}
