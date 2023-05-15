using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
public class ServiceCategorySite : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(ServiceCategory))]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    public Guid SiteId { get; set; }
}
