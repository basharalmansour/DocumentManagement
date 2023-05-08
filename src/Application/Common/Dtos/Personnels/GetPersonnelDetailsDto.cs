using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Personnels;
public class GetPersonnelDetailsDto
{
    public int PersonnelId { get; set; }
    public string PersonnelName { get; set; }
}
