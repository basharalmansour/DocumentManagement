using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Entities.Definitions;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Vendors;
public class GetVendorDto : BasicVendorDto
{
    public RecordStatus Status { get; set; }
    public string Logo { get; set; }
    public LanguageString Description { get; set; }
    public VendorOwnership VendorOwnership { get; set; }
    public VendorType? VendorType { get; set; }
    public string OwnerName { get; set; }
    public string OwnerSurname { get; set; }
    public string Title { get; set; }
    public string CompanyName { get; set; }
    public string BrandName { get; set; }
    public string MersisNo { get; set; }
    public int ChamberOfCommerceId { get; set; }
    public string TradeRegistrationNo { get; set; }
    public int AddressInfoId { get; set; }
    public int TaxCountyId { get; set; }
    public int TaxRoomId { get; set; }
    public string TaxIdentityNumberId { get; set; }
    public List<int> Categories { get; set; }
}
