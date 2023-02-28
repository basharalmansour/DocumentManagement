using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Documents;
public class DocumentTemplateFileType
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Document")]
    public int DocumentTemplateId { get; set; }
    public DocumentTemplate Document { get; set; }
}
