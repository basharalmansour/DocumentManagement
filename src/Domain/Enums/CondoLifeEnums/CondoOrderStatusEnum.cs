using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Enums.CondoLifeEnums;

public enum CondoOrderStatusEnum
{
    Prepared = 1,
    Completed = 2,
    CommitFailed = 3,
    Refunded = 4,
    Void = 5,
    RefundFailed = 6,
    Unknown = 7
}
