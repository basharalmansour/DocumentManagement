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
    public string SendOtpMessage { get; set; }
    public string GetUserInfo { get; set; }
    public string Login { get; set; }
    public string ClientKey { get; set; }
    public string GetUserByPhoneNumberAndEmail { get; set; }
    public string PublishMessage { get; set; }
    public string GetSites { get; set; }
    public string GetSiteDetails { get; set; }
    public string GetZones { get; set; }
    public string GetZoneDetails { get; set; }
    public string GetBlocks { get; set; }
    public string GetBlockDetails { get; set; }
    public string GetUnits { get; set; }
    public string GetUnitDetails { get; set; }
    public string GetAreas { get; set; }
    public string GetAreaDetails { get; set; }
    public string GetCompanies { get; set; }
    public string GetCompanyDetails { get; set; }
    public string GetBrands { get; set; }
    public string GetBrandDetails { get; set; }
    public string GetDepartments { get; set; }
    public string GetPersonnels { get; set; }
    public string GetPersonnelDetails { get; set; }
    
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

