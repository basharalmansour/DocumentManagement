using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ServiceCategoryRoles : LightBaseEntity<int>, IEntity<int>
{
    public Role Role { get; set; }
    public List<ApproverDepartment> ApproverDepartments { get; set; }
    public List<ApproverPersonnel > ApproverPersonnels { get; set; }
    public List<ApproverUserGroup > ApproverUserGroups { get; set; }
    [ForeignKey("ServiceCategory")]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
}