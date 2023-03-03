using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums.CondoLifeEnums;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CondoAdvantageDto
{
    public int? id { get; set; }
    public int status { get; set; }
    //public CondoAdvantageType sourceType { get; set; }
    public int memberShipId { get; set; }
    public bool hasQuota { get; set; }
    public int quota { get; set; }
    public string name { get; set; }
    public string siteId { get; set; }
    public int? integrationAdvantageId { get; set; }

}
