using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Orders.CreateDtos;
public class CreateOrderVehicleDto
{
    public int VehicleId { get; set; }
    public List<CreateOrderVehicleDriverDto> Drivers { get; set; }
    public List<CreateOrderDocumentDto> Documents { get; set; }
}
