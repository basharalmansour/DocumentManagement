﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ServiceCategoryRole : LightBaseEntity<int>, IEntity<int>
{
    public Role Role { get; set; }
    public List<ResponsibleDepartment> ResponsibleDepartments { get; set; }
    public List<ResponsiblePersonnel> ResponsiblePersonnels { get; set; }
    public List<ResponsibleUserGroup> ResponsibleUserGroups { get; set; }
    [ForeignKey(nameof(ServiceCategory))]
    public int ServiceCategoryId { get; set; }
    public ServiceCategoryDetails ServiceCategory { get; set; }
}