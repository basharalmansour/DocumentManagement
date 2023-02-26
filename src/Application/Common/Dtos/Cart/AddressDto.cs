using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Cart;

public class AddressDto
{
    public int CountryId { get; set; } 
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public string Email { get; set; }
}
