using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;

namespace CleanArchitecture.Application.Common.Dtos.UserGroup;
public class UserGroupApproversDto 
{
    public int PersonnelId { get; set; }
    public string PersonnelName { get; set; }
    public List<BasicServiceCategoryDto> ServiceCategories { get; set; }
}
