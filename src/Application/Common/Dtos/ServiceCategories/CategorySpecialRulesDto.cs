using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Definitions.SpecialRules;
using CleanArchitecture.Domain.Entities.SeviceCategories;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class CategorySpecialRulesDto
{
    public int SpecialRuleId { get; set; }
}