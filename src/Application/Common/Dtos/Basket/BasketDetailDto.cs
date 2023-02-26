using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Basket;

public class BasketDetailDto
{
    public string Id { get; set; }
    public string StartPoint { get; set; }
    public string Endpoint { get; set; }
    public DateTime Date { get; set; }
    public string ServiceName { get; set; }
    public string Detail { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public string ImageUrl { get; set; } 
}
