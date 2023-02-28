using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.PresenceGroups;

namespace CleanArchitecture.Domain.Entities.Documents.DocumentPresences;
public class DocumentPresence
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Document")]
    public int DocumentId { get; set; }
    public DocumentTemplate Document { get; set; }

    [ForeignKey("Group")]
    public int PresenceGroupId { get; set; }
    public PresenceGroup Group { get; set; }
}
