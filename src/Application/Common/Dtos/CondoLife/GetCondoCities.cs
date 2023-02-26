using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums.CondoLifeEnums;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class GetCondoCities
{
    public int id { get; set; }
    public int regionId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}
