using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Cart;

public class BuyCartDto
{
    public string UserId { get; set; } 
    public int? NationalityId { get; set; }
    public InvoiceType? InvoiceType { get; set; }
    public CompanyInvoiceAddressDto CompanyAddress { get; set; }
    public PersonalInvoiceAddressDto PersonalAddress { get; set; }
    public AddressDto Address { get; set; }
    public string HomePhoneNumber { get; set; }
    public string Fax { get; set; }
    public bool IsMarried { get; set; }
    public DateTime? MarriedDate { get; set; }
    public bool IsInvoiceAndDeliveryAddressSame { get; set; }
    public int MembershipId { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
    public bool ElectronicMessagePermission { get; set; }
    public bool AgreementTextAccept { get; set; }
}
