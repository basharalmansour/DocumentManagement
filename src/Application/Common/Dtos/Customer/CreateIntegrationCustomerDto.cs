using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums.VeriSoftEnums;

namespace CleanArchitecture.Application.Common.Dtos.Customer;

public class CreateIntegrationCustomerDto
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string WorkAddress { get; set; }
    public VerisoftGender GenderId { get; set; }
    public string Password { get; set; }
    public bool KvkkPermissionAccept { get; set; }
    public string PostCode { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; }
    public string HomePhoneNumber { get; set; }
    public string Faks { get; set; }
    public DateTime DateOfMarriage { get; set; }
    public VerisoftMaritialStatus MaritialStatus { get; set; }
    public bool AgreementTextAccept { get; set; }
    public string IdentityNumber { get; set; }
    public string CountryPhoneCode { get; set; }
    public string IntegrationUserId { get; set; }
    public DateTime BirthDate { get; set; }
    public string TavPassportNo { get; set; }
    public bool ElectronicMessagePermission { get; set; }
}
