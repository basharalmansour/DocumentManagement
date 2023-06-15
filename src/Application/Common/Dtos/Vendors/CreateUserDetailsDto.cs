using CleanArchitecture.Domain.Entities.Definitions;

namespace CleanArchitecture.Application.Common.Dtos.Vendors;

public class CreateUserDetailsDto
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public bool IsPrimary { get; set; }
    public int VendorId { get; set; }
    public CreateAddressInfoDto AddressInfo { get; set; }
}