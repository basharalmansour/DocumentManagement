using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetUnitsResponseDto
{
    public int Id { get; set; }
    public string UnitDefaultPicture { get; set; }
    public Guid SiteId { get; set; }
    public string SiteCode { get; set; }
    public string ZoneCode { get; set; }
    public string BlockCode { get; set; }
    public string GeneratedUnitName { get; set; }
    public string UnitType { get; set; }
    public string SiteName { get; set; }
    public string DoorNumber { get; set; }
    public string Floor { get; set; }
    public bool Selected { get; set; }
    public string UnitCode { get; set; }
    public int? UnitForStatusId { get; set; }
}
