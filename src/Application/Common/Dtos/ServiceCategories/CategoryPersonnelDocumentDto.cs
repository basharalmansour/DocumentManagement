using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.SeviceCategories;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class CategoryPersonnelDocumentDto
{
    public int ServiceCategoryId { get; set; }
    public int DocumentTemplateId { get; set; }
}
