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
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
public class ServiceCategoryVehicleTemplateDocument : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("VehicleTemplateCategory")]
    public int VehicleTemplateCategoryId { get; set; }
    public ServiceCategoryVehicleTemplate ServiceCategoryVehicleTemplate { get; set; }

    [ForeignKey ("DocumentTemplate")]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    public bool IsRequired { get; set; }
    public VehicleDocumentType VehicleDocumentType { get; set; }
} 