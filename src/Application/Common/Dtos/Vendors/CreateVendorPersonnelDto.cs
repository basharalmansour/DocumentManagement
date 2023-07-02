using CleanArchitecture.Domain.Entities.Vehicles;
using CleanArchitecture.Domain.Entities.Vendors;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Vendors;

public class CreateVendorPersonnelDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Telephone { get; set; }
    public string IdentityNo { get; set; }
    public string Email { get; set; }
    public bool IsDriver { get; set; }
    public List<int> Vehicles { get; set; }
}