using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Forms;
public class QuestionDateOptions
{
    [Key]
    public int Id { get; set; }
    public bool IsMultiDate { get; set; }
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public Question Question { get; set; }
}
