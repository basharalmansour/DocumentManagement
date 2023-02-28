﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.PresenceGroups;
public class PresenceGroupArea
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Group")]
    public int PresenceGroupId { get; set; }
    public PresenceGroup Group { get; set; }
    public int AreaId { get; set; }
}
