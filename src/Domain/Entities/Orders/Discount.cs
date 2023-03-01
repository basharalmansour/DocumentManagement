using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Orders;

public class Discount : BaseEntity<int> , ISoftDeletable, IAuditable, IEntity<int> 
{

    public string SiteId { get; set; }
    public int IntegrationMembershipId { get; set; }
    public double Ratio { get; set; }
    
}
