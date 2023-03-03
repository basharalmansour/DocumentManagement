using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetSiteDetailsResponseDto
{
    public Guid Id { get; set; }
    public int? CityId { get; set; }
    public int? DistrictId { get; set; }
    public string Description { get; set; }
    public string DescriptionEn { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
    public string Web { get; set; }
    public string Address { get; set; }
    public string AddressLat { get; set; }
    public string AddressLong { get; set; }
    public bool? IsCommissionSameAsParent { get; set; }
    public bool VisitorEntryVerification { get; set; }
    public double Commission { get; set; }
    public List<string> Tags { get; set; }
    public string FileURL { get; set; }
    public Guid ParentSiteId { get; set; }
    public string Name { get; set; }
    public string NameEn { get; set; }
    public string Code { get; set; }
    public string DefaultUnitLogo { get; set; }
    public IEnumerable<int> SegmentsMappeds { get; set; }
    public IEnumerable<int> Languages { get; set; }
    public int ZonesCount { get; set; }
    public int BlockCount { get; set; }
    public int UnitCount { get; set; }
    public int AssetCount { get; set; }
    public int AreaCount { get; set; }
    public bool IsActive { get; set; }
    public int HardwareCount { get; set; }
    public bool IsMain { get; set; }
    public string BusinessTitle { get; set; }
}
