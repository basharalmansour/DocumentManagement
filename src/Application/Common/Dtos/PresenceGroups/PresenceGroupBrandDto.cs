using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;

namespace CleanArchitecture.Application.Common.Dtos.PresenceGroups;
public  class PresenceGroupBrandDto
{
    public int BrandId { get; set; }
    public string BrandName { get; set; }
}
