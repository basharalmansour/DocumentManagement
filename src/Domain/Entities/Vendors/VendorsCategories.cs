using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Vendors;
public class VendorsCategories
{
    public int Id { get; set; }
    [ForeignKey(nameof(Vendor))]
    public int VendorId { get; set; }
    public Vendor Vendor { get; set; }

    [ForeignKey(nameof(VendorCategory))]
    public int VendorCategoryId { get; set; }
    public VendorCategory VendorCategory { get; set; }
}
