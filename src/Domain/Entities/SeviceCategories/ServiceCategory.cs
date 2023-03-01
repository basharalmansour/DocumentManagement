using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    [StringLength(StringLengths.MediumString)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
    public int MaxPersonnelCount { get; set; } 

    [ForeignKey("ParentServiceCategory") ] 
    public int ParentServiceCategoryId { get; set; } 
    public ServiceCategory ParentServiceCategory { get; set; } 

    [ForeignKey("ServiceCategoryApprovment") ] 
    public int ServiceCategoryApprovmentId { get; set; } 
    public ServiceCategoryApprovment ServiceCategoryApprovment { get; set; } 
    public List<ServiceCategory> SubServiceCategories { get; set; }
}
