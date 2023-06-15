using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Entities.Definitions;
using CleanArchitecture.Domain.Entities.Vehicles;
using CleanArchitecture.Domain.Entities.Venders;
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Vendors;
public class GetVendorDto : BasicVendorDto
{
    public RecordStatus Status { get; set; }
    public string Logo { get; set; }
    public LanguageString Description { get; set; }
    public VendorOwnership VendorOwnership { get; set; }
    public VendorType VendorType { get; set; }
    public LanguageString OwnerName { get; set; }
    public LanguageString OwnerSurname { get; set; }
    public string Title { get; set; }
    public LanguageString CompanyName { get; set; }
    public string BrandName { get; set; }
    public string MersisNo { get; set; }
    public int ChamberOfCommerceId { get; set; }
    public string TradeRegistrationNo { get; set; }
    public int AddressInfoId { get; set; }
    public int TaxCountyId { get; set; }
    public int TaxRoomId { get; set; }
    public int TaxIdentityNumberId { get; set; }
    public List<VendorsCategoriesDto> VendorsCategories { get; set; }
}
