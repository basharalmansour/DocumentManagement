using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.Orders;

public class Discount : ISoftDeletable, IAuditable, IEntity<int>
{
    public int Id { get; set; }
    public string SiteId { get; set; }
    public int IntegrationMembershipId { get; set; }
    public double Ratio { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string DeletedBy { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    
}
