using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderVehicleDriverDocument : LightBaseEntity<int>
{
    [ForeignKey(nameof(OrderVehicleDriver))]
    public int OrderVehicleDriverId { get; set; }
    public OrderVehicleDriver OrderVehicleDriver { get; set; }

    [ForeignKey(nameof(ServiceCategoryVehicleTemplateDocument))]
    public int ServiceCategoryVehicleTemplateDocumentId { get; set; }
    public ServiceCategoryVehicleTemplateDocument ServiceCategoryVehicleTemplateDocument { get; set; }

    [ForeignKey(nameof(Document))]
    public int DocumentId { get; set; }
    public Document Document { get; set; }
}
