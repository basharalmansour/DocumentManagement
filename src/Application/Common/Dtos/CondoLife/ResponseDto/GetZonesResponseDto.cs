﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetZonesResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
}
