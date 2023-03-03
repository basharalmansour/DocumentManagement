using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.UserGroup;
public class AddUserGroupRequest
{
    public string Name { get; set; }
    public List<int> PersonnelIds { get; set; }
    public string UniqueCode { get; set; }
}

