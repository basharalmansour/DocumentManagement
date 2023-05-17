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
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
public class ServiceCategoryVehicleTemplateDocument : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(ServiceCategoryVehicleTemplate))]
    public int ServiceCategoryVehicleTemplateId { get; set; }
    public ServiceCategoryVehicleTemplate ServiceCategoryVehicleTemplate { get; set; }

    [ForeignKey (nameof(DocumentTemplate))]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    public bool IsRequired { get; set; }
    public VehicleDocumentType VehicleDocumentType { get; set; }
} 