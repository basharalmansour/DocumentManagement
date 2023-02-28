using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.UserGroups;
public class UserGroupPersonnel
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Group")] 
    public int UserGroupId { get; set; }  
    public UserGroup Group { get; set; } 
    public int PersonnelId { get; set; } 
} 
