using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CreateCondoUserMembershipDto
{
    public int? Id { get; set; }
    public int Status { get; set; }
    public Guid UserId { get; set; }
    public int MemberShipId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid SiteId { get; set; }
}
