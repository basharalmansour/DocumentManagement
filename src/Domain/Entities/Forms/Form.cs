using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Entities.Documents;

namespace CleanArchitecture.Domain.Entities.Forms;
public class Form : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>//
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    public List<Question> Questions { get; set; }
    public List<DocumentTemplateForm> DocumentTemplates { get; set; }

    public override void DeleteByEdit()
    {
        if(Questions!= null)
            Questions.ForEach(x => x.DeleteByEdit());
        base.DeleteByEdit();
    }
}
