using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Documents;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
public  class ServiceCategoryPersonnelDocument : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("ServiceCategory")]
    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    [ForeignKey("DocumentTemplate")] 
    public int DocumentTemplateId { get; set; } 
    public DocumentTemplate DocumentTemplate { get; set; }
    public bool IsRequired { get; set; }
}
