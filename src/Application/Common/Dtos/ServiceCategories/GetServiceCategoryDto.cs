using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class GetServiceCategoryDto
{
    public int Id { get; set; }
    public string UniqueCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
    public int MaxPersonnelCount { get; set; }
    public int ParentServiceCategoryId { get; set; }
    public int ServiceCategoryApprovmentId { get; set; }
    public List<GetServiceCategoryDto> SubServiceCategories { get; set; }
}

