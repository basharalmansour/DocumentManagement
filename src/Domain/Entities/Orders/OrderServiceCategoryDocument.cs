using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderServiceCategoryDocument : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey(nameof(ServiceCategoryDocument))]
    public int ServiceCategoryDocumentId { get; set; }
    public ServiceCategoryDocument ServiceCategoryDocument { get; set; }

    [ForeignKey(nameof(Document))]
    public int DocumentId { get; set; }
    public Document Document { get; set; }
}
