﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
public  class GetDocumentTemplateDto
{
    public int Id { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string UniqueCode { get; set; }
    public string Name { get; set; }
    public bool HasValidationDate { get; set; }
    public int DocumentTemplateTypeId { get; set; }
}
