using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class QuestionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public QuestionType QuestionType { get; set; }
    public short AnswersCount { get; set; }
    public int FormId { get; set; }
}
