namespace CleanArchitecture.Domain.Common;

public class ClientSettings
{
    public CondoLifeClientSettings CondoLife { get; set; }
}
public class BaseClientSettings
{
    public string BaseUrl { get; set; } 
}

public class CondoLifeClientSettings : BaseClientSettings
{
    public string CreateUser { get; set; }
    public string UpdateUser { get; set; }
    public string CreateCondoUserMembership { get; set; }
    public string FilterProgram { get; set; }
    public string GetCities { get; set; }
    public string GetCountries { get; set; }
    public string GetDistricts { get; set; }
    public string SendOtpMessage { get; set; }
    public string GetUserInfo { get; set; }
    public string UpsertIntegrationAdvantage { get; set; }
    public string DeleteAdvantage { get; set; }
    public string GetUserInfoByIntegrationUserId { get; set; }
    public string OrderNotificationApiClientKey { get; set; }
    public string FindMembership { get; set; }
    public string MembershipsByIntegrationCode { get; set; }
    public string GetIntegrationAdvantages { get; set; }
    public string TavCode { get; set; }
    public string ClientKey { get; set; }
    public string GetIntegrationMembershipId { get; set; }
    public string Login { get; set; }
    public string GetUserMembership { get; set; }
    public string GetUserMembershipIdByUserId { get; set; }
    public string GetUserByPhoneNumberAndEmail { get; set; }
    public string TavSiteId { get; set; }
    public string PublishMessage { get; set; }
    public CondoCredential CredentialSettings { get; set; }
}
public class CondoCredential
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CountryPhoneCode { get; set; }
    public string Password { get; set; }
    public string Code { get; set; }
    public string SiteId { get; set; }
}

