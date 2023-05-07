using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;
using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class ServiceCategoryDto : BasicServiceCategoryDto
{
    public LanguageString Description { get; set; }
    
    public int? ParentServiceCategoryId { get; set; }
    public ServiceCategoryDetailsDto ServiceCategoryDetails { get; set; }
}
