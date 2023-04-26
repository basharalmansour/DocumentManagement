using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Entities.Forms;

namespace CleanArchitecture.Application.Common.Dtos.Forms;

public class BasicFormDto
{
    public int Id { get; set; }
    public LanguageString Name { get; set; }
    public string UniqueCode { get; set; }
}
public class FormDto: BasicFormDto
{
    public List<QuestionDto> Questions { get; set;  } 
}
