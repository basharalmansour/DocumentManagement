﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Vendors;
public class VendorCategory : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    [ForeignKey(nameof(ParentVendorCategory))]
    public int? ParentId { get; set; }
    public VendorCategory ParentVendorCategory { get; set; }
    public List<VendorCategory> SubVendorCategories { get; set; }
    public List<VendorsCategories> Vendors { get; set; }
}
