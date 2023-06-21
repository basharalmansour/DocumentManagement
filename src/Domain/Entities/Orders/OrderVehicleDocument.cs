using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;

namespace CleanArchitecture.Domain.Entities.Orders;
public class OrderVehicleDocument : LightBaseEntity<int>
{
    [ForeignKey(nameof(OrderVehicle))]
    public int OrderVehicleId { get; set; }
    public OrderVehicle OrderVehicle { get; set; }

    [ForeignKey(nameof(ServiceCategoryVehicleTemplateDocument))]
    public int ServiceCategoryVehicleTemplateDocumentId { get; set; }
    public ServiceCategoryVehicleTemplateDocument ServiceCategoryVehicleTemplateDocument { get; set; }

    [ForeignKey(nameof(Document))]
    public int DocumentId { get; set; }
    public Document Document { get; set; }
}
