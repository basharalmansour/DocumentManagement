using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CondoMemberShipShortResponseDto
{
    public int Id { get; set; }
    public int Rank { get; set; }
    public string MemberShipUniqueId { get; set; }

    public int TitleId { get; set; }
    public string Title { get; set; }

    public int DescriptionId { get; set; }
    public string Description { get; set; }
}
