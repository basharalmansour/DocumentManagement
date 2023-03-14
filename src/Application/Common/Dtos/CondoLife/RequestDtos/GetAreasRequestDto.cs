using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
public class GetAreasRequestDto
{
    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsRent { get; set; }
    public int?[] AreaTypeId { get; set; }
    public Guid? SiteId { get; set; }
    public Guid? NotIncludeZoneId { get; set; }
    public Guid? NotIncludeBlockId { get; set; }
    public int? NotIncludeUnitId { get; set; }
    public int? NotIncludeAreaId { get; set; }
}
