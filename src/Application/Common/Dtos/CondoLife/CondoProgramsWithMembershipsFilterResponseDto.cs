using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CondoProgramsWithMembershipsFilterResponseDto
{
    public int id { get; set; }
    public int programId { get; set; }
    public int siteId { get; set; }
    public string programUniqueId { get; set; }

    public int titleId { get; set; }
    public string title { get; set; }

    public int descriptionId { get; set; }
    public string description { get; set; }

    public List<CondoMemberShipShortResponseDto> memberShips { get; set; }
}

 