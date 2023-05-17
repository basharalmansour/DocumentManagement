using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.DocumentTemplates;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
public class DocumentTemplateZone : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(DocumentTemplate))]
    public int DocumentId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    public Guid ZoneId { get; set; }
}
