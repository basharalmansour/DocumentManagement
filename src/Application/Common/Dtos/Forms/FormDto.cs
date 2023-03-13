using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Forms;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class FormDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UniqueCode { get; set; }
    public List<QuestionDto> Questions { get; set;  } 
}
