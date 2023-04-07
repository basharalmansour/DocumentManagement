﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Documents;

namespace CleanArchitecture.Domain.Entities.Definitions.Vehicles;
public class VehiclesDocument
{
    [ForeignKey("DocumentTemplate")]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    [ForeignKey("Vehicle")]
    public int VehicleId { get; set; }
    public Vehicle Vehicle  { get; set; }
}
