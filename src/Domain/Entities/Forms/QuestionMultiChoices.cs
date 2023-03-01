using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Forms;
public class QuestionMultiChoices
{
    [Key]
    public int Id { get; set; }
    public string Choice { get; set; } 
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public Question Question { get; set; }
}