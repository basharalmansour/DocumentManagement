using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.PresenceGroups;
public  class BasicPresenceGroupDto
{
    public LanguageString Name { get; set; }
    public string UniqueCode { get; set; }
}
