using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Documents;

namespace CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
public class DocumentTemplateCompany : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(DocumentTemplate))]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    public int CompanyId { get; set; }
}
