﻿using System;
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
public class DocumentTemplateBlock : LightBaseEntity<int>, IEntity<int>
{
    [ForeignKey(nameof(DocumentTemplate))]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate DocumentTemplate { get; set; }
    public Guid BlockId { get; set; }
}
