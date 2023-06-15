using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Vendors;

namespace CleanArchitecture.Domain.Entities.Definitions;
public class UserDetails : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public bool IsPrimary { get; set; }

    [ForeignKey(nameof(AddressInfo))]
    public int AddressInfoId { get; set; }
    public AddressInfo AddressInfo { get; set; }

    [ForeignKey(nameof(Vendor))]
    public int VendorId { get; set; }
    public Vendor Vendor { get; set; }
}
