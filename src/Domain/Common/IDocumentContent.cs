using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.DocumentTemplates;

namespace CleanArchitecture.Domain.Common;
public interface IDocumentContent
{
    int DocumentTemplateId { get; set; }
    DocumentTemplate DocumentTemplate { get; set; }
    bool IsRequired { get; set; }
}
