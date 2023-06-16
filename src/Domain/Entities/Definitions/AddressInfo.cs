using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Definitions;
public class AddressInfo : LightBaseEntity<int>
{
    public EmailAddressAttribute Email { get; set; }
    public string PhoneNo { get; set; }
    public string Address { get; set; }
    public int? CountyId { get; set; }
    public int? CityId { get; set; } 
    public string PostalCode { get; set; } 
}
