﻿using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Vehicles;
using CleanArchitecture.Domain.Entities.Vendors;

namespace CleanArchitecture.Domain.Entities.Vendors;
public class VendorPersonnel : BaseEntity<int>, IEntity<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Telephone { get; set; }
    public string IdentityNo { get; set; }
    public string Email { get; set; }
    public string Title { get; set; }
    public bool IsDriver { get; set; }
    public bool IsActive { get; set; }

    [ForeignKey(nameof(Vendor))]
    public int VendorId { get; set; }
    public Vendor Vendor { get; set; }
    public List<VehiclePersonnel> Vehicles { get; set; }
}
