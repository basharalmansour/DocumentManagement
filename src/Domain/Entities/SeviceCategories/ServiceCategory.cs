using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories;
public class ServiceCategory : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxServiceTime { get; set; }
    public TimeUnit ServiceTimeUnit { get; set; }
    public int MaxPersonnelCount { get; set; } 

    [ForeignKey("Parent") ] 
    public int ParentCategoryId { get; set; } 
    public ServiceCategory Parent { get; set; } 
    public List<ServiceCategory> Children { get; set; }

    [ForeignKey ("Presence")]
    public int PresenceId { get; set; }
    public Presence Presence { get; set; }

    [ForeignKey("Approver")]
    public int ApproverId { get; set; }
    public Approver Approver { get; set; }
}
