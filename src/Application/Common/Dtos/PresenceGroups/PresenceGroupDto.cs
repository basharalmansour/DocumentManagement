using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;

namespace CleanArchitecture.Application.Common.Dtos.PresenceGroups;
public class PresenceGroupDto
{
    public LanguageString Name { get; set; }
    public string UniqueCode { get; set; }
    public List<PresenceGroupAreaDto> PresenceGroupAreas { get; set; }
    public List<PresenceGroupBlockDto> PresenceGroupBlocks { get; set; }
    public List<PresenceGroupCompanyDto> PresenceGroupCompanies { get; set; }
    public List<PresenceGroupBrandDto> PresenceGroupBrands { get; set; }
    public List<PresenceGroupSiteDto> PresenceGroupSites { get; set; }
    public List<PresenceGroupUnitDto> PresenceGroupUnits { get; set; }
    public List<PresenceGroupZoneDto> PresenceGroupZones { get; set; }
} 