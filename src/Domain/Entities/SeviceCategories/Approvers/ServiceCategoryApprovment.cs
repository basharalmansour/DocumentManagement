﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ServiceCategoryApprovment : LightBaseEntity<int>, IEntity<int>
{
    public bool IsParallel { get; set; }
    public List<ApproverDepartment> ApproverDepartments { get; set; }
    public List<ApproverPersonnel > ApproverPersonnels { get; set; }
    public List<ApproverUserGroup > ApproverUserGroups { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
}
