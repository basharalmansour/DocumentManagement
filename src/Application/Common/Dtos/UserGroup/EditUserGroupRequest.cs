using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.UserGroup;
public class EditUserGroupRequest : AddUserGroupRequest
{
    public int Id { get; set; }
}
