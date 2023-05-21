using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Venders;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderPersonnel : BaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey(nameof(VendorPersonnel))]
    public int VendorPersonnelId { get; set; }
    public VendorPersonnel VendorPersonnel { get; set; }
}
