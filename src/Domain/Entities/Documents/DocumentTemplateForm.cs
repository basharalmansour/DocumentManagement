using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Forms;

namespace CleanArchitecture.Domain.Entities.Documents;
public class DocumentTemplateForm : LightBaseEntity<int>, IEntity<int>//
{
    [ForeignKey(nameof(DocumentTemplate))]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }

    [ForeignKey("Form")]
    public int FormId { get; set; }
    public Form Form { get; set; }
}
