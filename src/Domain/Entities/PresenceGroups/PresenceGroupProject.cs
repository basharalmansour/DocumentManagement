using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.PresenceGroups;
public  class PresenceGroupProject
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Group")]
    public int PresenceGroupId { get; set; }
    public PresenceGroup Group { get; set; }
    public int ProjectId { get; set; }
}
