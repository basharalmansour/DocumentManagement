using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetDepartmentsResponseDto
{
    public string WorkUnitTitle { get; set; }
    public string WorkUnitTitleEn { get; set; }
    public string WorkUnitDescription { get; set; }
    public sbyte Sequence { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
}
