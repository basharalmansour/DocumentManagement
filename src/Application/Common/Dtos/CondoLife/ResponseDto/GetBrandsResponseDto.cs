using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetBrandsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameEn { get; set; }
    public string Logo { get; set; }
}
