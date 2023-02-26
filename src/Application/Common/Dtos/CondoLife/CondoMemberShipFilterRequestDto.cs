using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CondoMemberShipFilterRequestDto
{
    public string SearchText { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
