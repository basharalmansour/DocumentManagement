using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Documents.DocumentPresences;
public class DocumentCompany
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Document")] 
    public int DocumentId { get; set; } 
    public DocumentTemplate Document { get; set; } 
    public int UnitId { get; set; } 
}
