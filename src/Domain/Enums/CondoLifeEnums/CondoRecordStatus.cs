using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Enums.CondoLifeEnums;

public enum CondoRecordStatus
{
    Active = 1,
    Passive = 2,
    Deleted = 3,
    Draft = 4,
}

public enum CondoAdvantageType
{
    Condolife = 1,
    Verisoft = 2,
}
