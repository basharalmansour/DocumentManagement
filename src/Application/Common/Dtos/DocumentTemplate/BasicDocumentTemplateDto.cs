using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
public class BasicDocumentTemplateDto
{
    public int Id { get; set; }
    public string UniqueCode { get; set; }
    public LanguageString Name { get; set; }
}