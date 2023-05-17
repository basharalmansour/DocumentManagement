using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.DocumentTemplates;
public class DocumentTemplate : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>//
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    public bool HasValidationDate { get; set; }
    public List<DocumentTemplateFileType> DocumentTemplateFileTypes { get; set; }

    [ForeignKey(nameof(DocumentTemplateType))]
    public int DocumentTemplateTypeId { get; set; }
    public DocumentTemplateType DocumentTemplateType { get; set; }

    public List<DocumentTemplateForm> Forms { get; set; }

}
