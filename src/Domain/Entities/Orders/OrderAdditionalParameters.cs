using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderAdditionalParameters : IEntity<Guid>
{
    [Key]
    [ForeignKey(nameof(Order))]
    public Guid Id { get; set; }
    public Order Order { get; set; }
    public string PresenceName { get; set; } 
    public string UserName { get; set; } //
}
