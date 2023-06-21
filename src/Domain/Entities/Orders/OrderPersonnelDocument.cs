using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderPersonnelDocument : LightBaseEntity<int>
{
    [ForeignKey(nameof(OrderPersonnel))]
    public int OrderPersonnelId { get; set; }
    public OrderPersonnel OrderPersonnel { get; set; }

    [ForeignKey(nameof(ServiceCategoryPersonnelDocument))]
    public int ServiceCategoryPersonnelDocumentId { get; set; }
    public ServiceCategoryPersonnelDocument ServiceCategoryPersonnelDocument { get; set; }

    [ForeignKey(nameof(Document))]
    public int DocumentId { get; set; }
    public Document Document { get; set; }
}
