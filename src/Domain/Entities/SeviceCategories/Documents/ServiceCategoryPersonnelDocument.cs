using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.DocumentTemplates;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
public  class ServiceCategoryPersonnelDocument : LightBaseEntity<int>, IDocumentContent, IEntity<int>
{
    [ForeignKey(nameof(ServiceCategory))]
    public int ServiceCategoryId { get; set; }
    public ServiceCategoryDetails ServiceCategory { get; set; }
    [ForeignKey(nameof(DocumentTemplate))] 
    public int DocumentTemplateId { get; set; } 
    public DocumentTemplate DocumentTemplate { get; set; }
    public bool IsRequired { get; set; }
}
