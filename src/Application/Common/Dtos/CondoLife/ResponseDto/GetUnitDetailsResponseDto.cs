using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetUnitDetailsResponseDto
{
    public int Id { get; set; }
    public Guid SiteId { get; set; }
    public Guid? ZoneId { get; set; }
    public Guid? BlockId { get; set; }
    public string Code { get; set; }
    public string AvenueName { get; set; }
    public string StreetName { get; set; }
    public string ParkingNumber { get; set; }
    public int? TransformerId { get; set; }
    public Guid RepresentativeAreaId { get; set; }
    public int? WaterStorageTankId { get; set; }
    public int UnitTypeId { get; set; }
    public string UnitTypeName { get; set; }
    public int UnitTypeSubId { get; set; }
    public int? UnitTypeCategoryId { get; set; }
    public int? LivingPeopleCount { get; set; }
    public int? BrandId { get; set; }
    public int? CompanyId { get; set; }
    public int? GuestCount { get; set; }
    public int? UnitCarCapacity { get; set; }
    public int UnitForStatusId { get; set; }
    public string Floor { get; set; }
    public string ImageURL { get; set; }
    public string FileURL { get; set; }
    public int SquareMeterGross { get; set; }
    public int SquareMeterNet { get; set; }
    public int TotalDemandCount { get; set; }
    public string DoorNumber { get; set; }
    public bool IsActive { get; set; }
    public bool IsRent { get; set; }
    public string DeedNumber { get; set; }
    public string RootLivingNameSurname { get; set; }
    public Guid? RootLivingUserId { get; set; }
    public decimal Price { get; set; }
    public string About { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ModifyDate { get; set; }
}
