using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Cart;

public class PersonalInvoiceAddressDto : AddressDto
{
    public string Email { get; set; }
    public string IdentityNumber { get; set; }
}
