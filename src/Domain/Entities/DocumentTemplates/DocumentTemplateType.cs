using System;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.DocumentTemplates;
public class DocumentTemplateType : LightBaseEntity<int>, IEntity<int>//
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; } 
}
