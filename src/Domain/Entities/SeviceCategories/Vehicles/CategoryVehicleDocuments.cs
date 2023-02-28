using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
public class CategoryVehicleDocuments
{
    [Key ]
    public int Id { get; set; }
    [ForeignKey("Vehicle")]
    public int VehicleId { get; set; }
    public VehicleCategory Vehicle { get; set; }
    [ForeignKey ("Document")]
    public int DocumentId { get; set; }
    public DocumentTemplate Document { get; set; }
    public VehicleDocumentType VehicleDocumentType { get; set; }
} 