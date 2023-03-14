using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.UserGroups;
public class UserGroupPersonnel : LightBaseEntity<int>, IEntity<int>
{
    public int PersonnelId { get; set; }
    [ForeignKey("UserGroup")] 
    public int UserGroupId { get; set; }  
    public UserGroup UserGroup { get; set; } 
} 