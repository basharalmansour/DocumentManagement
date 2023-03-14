using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
public  class GetDocumentTemplateDto
{
    public int Id { get; set; }
    public string UniqueCode { get; set; }
    public string Name { get; set; }
    public bool HasValidationDate { get; set; }
    public int DocumentTemplateTypeId { get; set; }
    public List<DocumentFileType> DocumentTemplateFileTypes { get; set; }
}
