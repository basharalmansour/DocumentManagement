using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.UserGroups;

namespace CleanArchitecture.Application.Common.Dtos.UserGroup;
public class GetUserGroupDto
{
    public string Name { get; set; }
    public List<UserGroupPersonnelDto> Personnels { get; set; }
} 
