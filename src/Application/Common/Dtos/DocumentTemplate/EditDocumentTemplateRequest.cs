using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
public  class EditDocumentTemplateRequest:AddDocumentTemplateRequest
{
    public int Id { get; set; }
}
