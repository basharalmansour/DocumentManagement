﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ResponsiblePersonnel : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("ServiceCategoryRole")]
    public int ServiceCategoryRoleId { get; set; }
    public ServiceCategoryRole ServiceCategoryRole { get; set; }
    public int PersonnelId { get; set; }
}
