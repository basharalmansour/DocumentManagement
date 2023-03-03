using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
public class GetUnitsRequestDto
{
    public Dictionary<UnitFilter, string> UnitFilter { get; set; }
    public int? UnitType { get; set; }
    public int? UnitTypeSub { get; set; }
    public int? UnitTypeCategory { get; set; }
    public int? UnitTypeCode { get; set; }
    public Guid? RepresentativeAreaId { get; set; }
    public bool IsActive { get; set; }
    public Guid? SiteId { get; set; }
    public Guid? NotIncludeZoneId { get; set; }
    public Guid? NotIncludeBlockId { get; set; }
}

public enum UnitFilter
{
    // [Display(Name = "Site")]
    // Site = 1,
    [Display(Name = "Bölge")]
    Zones = 2,
    [Display(Name = "Blok")]
    Block = 3,
    [Display(Name = "Temsilci")]
    Respresenter = 4,
    // [Display(Name = "Soyad")]
    // Surname = 5,
    // [Display(Name = "Telefon Numarası")]
    // PhoneNumber = 6,
    [Display(Name = "Ünite Kodu")]
    UnitNo = 7,
    // [Display(Name = "Ad")]
    // Name = 8,
    [Display(Name = "Kapı Numarası")]
    DoorNumber = 9,
    [Display(Name = "Unite Tipi")]
    UnitType = 10,
    [Display(Name = "Ünite Adı")]
    UnitName = 11,
    [Display(Name = "Unite Alt Tipi")]
    UnitTypeSub = 12
}
