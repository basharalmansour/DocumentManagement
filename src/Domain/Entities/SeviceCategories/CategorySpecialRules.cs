using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.SeviceCategories;
public class CategorySpecialRules
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Category")]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory Category { get; set; }
    [ForeignKey ("SpecialRule")]
    public int SpecialRuleId { get; set; }
    public SpecialRule SpecialRule { get; set; }
}
