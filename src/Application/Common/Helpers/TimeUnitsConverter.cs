using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Helpers;
public class TimeUnitsConverter
{
    public static int ConvertToMinutes(int duration, TimeUnit unit)
    {
        switch (unit)
        {
            case TimeUnit.Years:
                return duration * 60 * 24 * 365;
            case TimeUnit.Months:
                return duration * 60 * 24 * 30;
            case TimeUnit.Weeks:
                return duration * 60 * 24 * 7;
            case TimeUnit.Days:
                return duration * 60 * 24;
            case TimeUnit.Hours:
                return duration * 60;
            default: 
                return duration;
        }
    }
}
