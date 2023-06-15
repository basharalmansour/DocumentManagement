using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.Vendors;
public class BasicVendorDto
{
    public int Id { get; set; }
    public LanguageString Name { get; set; }
    public List<string> VendorCategoryName { get; set; }
}
