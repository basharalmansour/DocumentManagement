using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
public class AddDocumentTemplateRequest
{
    public string Name { get; set; }
    public AddDocumentTemplateType DocumentTemplateType { get; set; }
    public List<DocumentFileType> DocumentFileType { get; set; }
    public bool HasValidationDate { get; set; }
    public string UniqueCode { get; set; }
}
