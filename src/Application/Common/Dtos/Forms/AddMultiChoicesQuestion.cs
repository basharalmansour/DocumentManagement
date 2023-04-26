using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class AddMultiChoicesQuestion
{
    public LanguageString Choice { get; set; }
    public int QuestionId { get; set; }
}