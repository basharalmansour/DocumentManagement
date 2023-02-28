using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Definitions.SpecialRules;

namespace CleanArchitecture.Domain.Entities.SeviceCategories;
public class CategorySpecialRules : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("ServiceCategory")]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }

    [ForeignKey ("SpecialRule")]
    public int SpecialRuleId { get; set; }
    public SpecialRule SpecialRule { get; set; }
}
