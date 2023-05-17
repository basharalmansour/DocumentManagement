using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.DocumentTemplates;
public class DocumentTemplateFileType : LightBaseEntity<int>, IEntity<int>//
{
    [ForeignKey(nameof(DocumentTemplate))]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    public DocumentFileType FileType { get; set; } 
}
