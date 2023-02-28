using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.SeviceCategories;

namespace CleanArchitecture.Domain.Entities.Documents;
public class CategoryDocument
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public ServiceCategory Category { get; set; }
    [ForeignKey("Document")]
    public int DocumentId { get; set; }
    public DocumentTemplate Document { get; set; }
}
