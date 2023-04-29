using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.Vehicles;
public class BasicVehicleDto
{
    public string Id { get; set; }
    public LanguageString Name { get; set; }
}
