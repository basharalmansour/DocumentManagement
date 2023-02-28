using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.UserGroups;
public class UserGroup : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    public string Name { get; set; }
}
