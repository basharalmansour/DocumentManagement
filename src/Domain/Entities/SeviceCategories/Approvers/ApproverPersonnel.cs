using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ApproverPersonnel : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("ServiceCategoryApprovment")]
    public int ServiceCategoryApprovmentId { get; set; }
    public ServiceCategoryApprovment ServiceCategoryApprovment { get; set; }
    public int PersonnelId { get; set; }
}
