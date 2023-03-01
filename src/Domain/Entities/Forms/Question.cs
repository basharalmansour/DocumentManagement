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
public class Question : LightBaseEntity<int>, IEntity<int>
{
    public string Name { get; set; }
    public QuestionType QuestionType { get; set; }
    public short? AnswersCount { get; set; }
    [ForeignKey("Form")]
    public int FormId { get; set; }
    public Form Form { get; set; }

}
