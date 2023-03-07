using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
public class GetDepartmentsRequestDto
{
    public Guid SiteId { get; set; }
    public bool IsActive { get; set; }
}
