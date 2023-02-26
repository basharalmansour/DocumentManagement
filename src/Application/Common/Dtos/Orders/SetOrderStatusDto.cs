using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums.CondoLifeEnums;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class SetOrderStatusDto
{
    public string TrackingNumber { get; set; }
    public string PosResponse { get; set; }
    public CondoOrderStatusEnum Status { get; set; }
    public string OrderNo { get; set; }
    public string Key { get; set; }
}
