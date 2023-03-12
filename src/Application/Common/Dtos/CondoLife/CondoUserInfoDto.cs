using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CondoUserInfoDto
{
    public Guid siteId { get; set; }
    public string avmUserCode { get; set; }
    public int avmUserDetailId { get; set; }
    public string profileImageUrl { get; set; }
    public string userId { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string countryPhoneCode { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }
    public int? genderId { get; set; }
    public string genderDescription { get; set; }
    public DateTime? birthDate { get; set; }
    public int userSegmentId { get; set; }
    public string userSegmentDescription { get; set; }
    public DateTime? registerDate { get; set; }
    public DateTime? lastLoginDate { get; set; }
    public int deviceSegment { get; set; }
    public string deviceModel { get; set; }
    public bool isAppUser { get; set; }
    public bool isWifiUser { get; set; }
    public bool isActiveUser { get; set; }
    public bool hasMobilePayment { get; set; }
    public bool isAgreementTextAccepted { get; set; }
    public bool isKvkkPermissionAccepted { get; set; }
    public bool isConsentTextAccepted { get; set; }
    public int loginCount { get; set; }
    public bool isDeleted { get; set; }
    public bool isActive { get; set; }
    public string tavPassportNo { get; set; }
    public string integrationUserId { get; set; }
    public DateTime memberShipEndDate { get; set; }
    public string citizenNumber { get; set; }
    public bool maritialStatus { get; set; }
    public DateTime maritialDate { get; set; }
}
