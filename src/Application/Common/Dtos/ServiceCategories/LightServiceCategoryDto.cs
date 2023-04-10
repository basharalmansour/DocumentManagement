using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class LightServiceCategoryDto
{
    public int Id { get; set; }
    public string UniqueCode { get; set; }
    public string Name { get; set; }
    public List<LightServiceCategoryDto> SubServiceCategories { get; set; }
}
