﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;

namespace CleanArchitecture.Application.Common.Dtos.PresenceGroups;
public class PresenceGroupBlockDto
{
    public int PresenceGroupId { get; set; }
    public Guid BlockId { get; set; }
}
