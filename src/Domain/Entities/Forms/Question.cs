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

namespace CleanArchitecture.Domain.Entities.Forms;
public class Question : BaseEntity<int>, IEntity<int>//
{
    public string Name { get; set; }
    public QuestionType QuestionType { get; set; }
    
    /// <summary>
    /// in case of multi answers type or one of many type
    /// </summary>
    public short? AnswersCount { get; set; }
    public DateQuestionOptions DateQuestionOptions { get; set; }
    public FileQuestionOptions FileQuestionOptions { get; set; }
    public List<MultiChoicesOption> MultiChoicesOptions { get; set; }
    [ForeignKey("Form")]
    public int FormId { get; set; }
    public Form Form { get; set; }

    public override void DeleteByEdit()
    {
        MultiChoicesOptions.ForEach(x => x.DeleteByEdit());
        base.DeleteByEdit();
    }
}
