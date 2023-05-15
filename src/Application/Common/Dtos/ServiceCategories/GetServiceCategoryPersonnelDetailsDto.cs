using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class GetServiceCategoryPersonnelDetailsDto
{
    public int MaxPersonnelCount { get; set; }
    public List<BasicDocumentTemplateDto> Documents { get; set; }

}
