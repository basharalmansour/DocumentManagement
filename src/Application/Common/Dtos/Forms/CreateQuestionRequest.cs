using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class CreateQuestionRequest
{
    public LanguageString Name { get; set; }
    public QuestionType QuestionType { get; set; }
    public short? AnswersCount { get; set; }
    public AddDateQuestionOptionsRequest DateQuestionOptions { get; set; }
    public AddFileQuestionOptionsRequest FileQuestionOptions { get; set; }
    public List<AddMultiChoicesQuestion> MultiChoicesQuestions { get; set; }
}
