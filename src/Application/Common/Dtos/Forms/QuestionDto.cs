using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class QuestionDto 
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public LanguageString Name { get; set; }
    public QuestionType QuestionType { get; set; }
    public short? AnswersCount { get; set; }
    public DateQuestionOptionsDto DateQuestionOptions { get; set; }
    public FileQuestionOptionsDto FileQuestionOptions { get; set; }
    public List<MultiChoicesQuestionDto> MultiChoicesQuestions { get; set; }
}
public class DateQuestionOptionsDto
{
    public bool IsMultiDate { get; set; }
}
public class FileQuestionOptionsDto
{
    public DocumentFileType DocumentFileType { get; set; }
}
public class MultiChoicesQuestionDto
{
    public LanguageString Choice { get; set; }
}