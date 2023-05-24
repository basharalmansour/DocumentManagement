using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Orders;
public class BasicOrderDto
{
    public Guid Id { get; set; }
    public string UniqueCode { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; } 
    public LanguageString Description { get; set; }
    public OrderStatus OrderStatus { get; set; }
}
