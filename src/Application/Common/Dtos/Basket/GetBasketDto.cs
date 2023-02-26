using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Basket;

public class GetBasketDto
{
    public string UniqueBasketId { get; set; }
    public List<BasketDetailDto> BasketDetail { get; set; } = new List<BasketDetailDto>();
}
