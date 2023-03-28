using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class AddQuestionRequest
{
    public string Name { get; set; }
    public QuestionType QuestionType { get; set; }
    public short AnswersCount { get; set; }
    public List<DateQuestionOptionsDto> DateQuestionOptions { get; set; }
    public List<FileQuestionOptionsDto> FileQuestionOptions { get; set; }
    public List<MultiChoicesQuestionDto> MultiChoicesQuestions { get; set; }
}
