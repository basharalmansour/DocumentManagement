using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CreateCondoUserMembershipResultDto
{
    public int Id { get; set; }
    public int MemberShipId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string ProfileImage { get; set; }
}
