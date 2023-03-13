using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
public class DocumentTemplateFileTypeDto
{
    public int DocumentTemplateId { get; set; }
    public DocumentFileType FileType { get; set; }
}
