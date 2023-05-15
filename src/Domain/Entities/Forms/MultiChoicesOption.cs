﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Forms;
public class MultiChoicesOption : BaseEntity<int>, IEntity<int>//
{
    public string Choice { get; set; } 
    [ForeignKey(nameof(Question))]
    public int QuestionId { get; set; }
    public Question Question { get; set; }
} 