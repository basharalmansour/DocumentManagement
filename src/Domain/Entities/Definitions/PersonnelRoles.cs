using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Definitions;
public class PersonnelRoles : LightBaseEntity<int>, IEntity<int>
{
    public Role Role { set; get; }
    public int PersonnelId { get; set; }
}
