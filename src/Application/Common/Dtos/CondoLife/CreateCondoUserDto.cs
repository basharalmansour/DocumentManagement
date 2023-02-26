using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CreateCondoUserDto
{
    public bool IsDeleted { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string CitizenNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string CountryPhoneCode { get; set; } 
    public DateTime CreateDate { get; set; }= DateTime.Now;
    public string WorkAddress { get; set; }
    public int? GenderId { get; set; }
    public string TavPassportNo { get; set; }
    public string IntegrationUserId { get; set; }
    public int DataSource { get; set; }
    public int DeviceSegment { get; } = 3;
    public DateTime MaritialDate { get; set; }
    public bool KvkkPermissionAccept { get; set; }
    public bool AgreementTextAccept { get; set; }
    public bool ElectronicMessagePermission { get; set; }
}
