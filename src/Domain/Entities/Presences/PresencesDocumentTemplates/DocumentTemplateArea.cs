using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
public class DocumentTemplateArea : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey("DocumentTemplate")]
    public int DocumentId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    public int AreaId { get; set; }
}
