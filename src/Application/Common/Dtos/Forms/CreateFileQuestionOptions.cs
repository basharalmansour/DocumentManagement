﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Forms;
public class CreateFileQuestionOptions
{
    public DocumentFileType DocumentFileType { get; set; }
}
