using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Forms;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class CreateDateQuestionOptions
{
    public bool IsMultiDate { get; set; }
}
