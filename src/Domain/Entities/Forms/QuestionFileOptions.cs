using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Forms;
public class QuestionFileOptions
{
    [Key]
    public int Id { get; set; }
    public DocumentFileType DocumentFileType { get; set; }
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public Question Question { get; set; }
}
