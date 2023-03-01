using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Entities.UserGroups;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ApproverUserGroup : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("ServiceCategoryApprovment")]
    public int ServiceCategoryApprovmentId { get; set; }
    public ServiceCategoryApprovment ServiceCategoryApprovment { get; set; }

    [ForeignKey("UserGroup")]
    public int UserGroupId { get; set; }
    public UserGroup UserGroup  { get; set; }
}
