using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities;
public class PersonnelRules: LightBaseEntity<int> , IEntity<int>
{
    public string Name { get; set; }
    public List<Rule> PersonRules { get; set; }
    public int PersonnelId { get; set; }
}
