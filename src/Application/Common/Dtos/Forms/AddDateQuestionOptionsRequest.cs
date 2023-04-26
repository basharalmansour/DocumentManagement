using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class AddDateQuestionOptionsRequest
{
    public bool IsMultiDate { get; set; }
    public int QuestionId { get; set; }
}
