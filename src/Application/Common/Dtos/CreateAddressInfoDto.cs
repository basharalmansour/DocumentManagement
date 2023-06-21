using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Common.Dtos;

public class CreateAddressInfoDto
{
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public string Address { get; set; }
    public int? CountyId { get; set; }
    public int? CityId { get; set; }
    public string PostalCode { get; set; }
}