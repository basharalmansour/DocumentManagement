using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Cart;

public class CompanyInvoiceAddressDto : AddressDto
{
    public string CompanyName { get; set; }
    public string TaxOffice { get; set; }
    public string TaxNumber { get; set; }
    public string Email { get; set; }
}
