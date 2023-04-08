using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.UserGroup;
public class UserGroupApproversDto 
{
    public int PersonnelId { get; set; }
    public string PersonnelName { get; set; }
    public List<int> CategoryIds { get; set; }
    public List<string> CategoryNames { get; set; }
}
