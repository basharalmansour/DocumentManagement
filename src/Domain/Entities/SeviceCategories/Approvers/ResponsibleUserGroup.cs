using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Entities.UserGroups;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ResponsibleUserGroup : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(ServiceCategoryRole))]
    public int ServiceCategoryRoleId { get; set; }
    public ServiceCategoryRole ServiceCategoryRole { get; set; }

    [ForeignKey(nameof(UserGroup))]
    public int UserGroupId { get; set; }
    public UserGroup UserGroup  { get; set; }
}
