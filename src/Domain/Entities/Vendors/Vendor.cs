using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Definitions;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.Vehicles;
using CleanArchitecture.Domain.Entities.Venders;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Vendors;
public class Vendor : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    public RecordStatus Status { get; set; }
    public string Logo { get; set; }
    public string Description { get; set; }
    public VendorOwnership? VendorOwnership { get; set; }
    public VendorType? VendorType { get; set; }

    [StringLength(StringLengths.VeryLongString)]
    public string OwnerName { get; set; }

    [StringLength(StringLengths.VeryLongString)]
    public string OwnerSurname { get; set; }
    public string Title { get; set; }

    [StringLength(StringLengths.VeryLongString)]
    public string CompanyName { get; set; }

    [StringLength(StringLengths.MediumString)]
    public string BrandName { get; set; }
    public string MersisNo { get; set; }
    public int ChamberOfCommerceId { get; set; }

    [StringLength(StringLengths.ShortString)]
    public string TradeRegistrationNo { get; set; }
    public int TaxCountyId { get; set; }
    public int TaxRoomId { get; set; }
    public string TaxIdentityNumberId { get; set; }
    public List<UserDetails> UserDetails { get; set; }

    [ForeignKey(nameof(AddressInfo))]
    public int AddressInfoId { get; set; }
    public AddressInfo AddressInfo { get; set; }
    public List<VendorPersonnel> VendorPersonnels { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public List<VendorsCategories> Categories { get; set; }
    public override void DeleteByEdit()
    {
        if (VendorPersonnels != null)
            VendorPersonnels.ForEach(x => x.DeleteByEdit());
        if (Vehicles != null)
            Vehicles.ForEach(x => x.DeleteByEdit());
        base.DeleteByEdit();
    }
}
