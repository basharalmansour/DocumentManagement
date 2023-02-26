using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CreateCondoOtpMessageDto
{
    public string Message { get; set; }
    public string Phone { get; set; }
    public string SiteId { get; set; }
}
