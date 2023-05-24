using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.Orders.CreateDtos;
public class CreateOrderEquipmentDto
{
    public LanguageString Name { get; set; }
    public bool IsNoise { get; set; }
    public bool IsHeat { get; set; }
}
