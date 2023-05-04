using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Common.Helpers;
public static class NullHandleProcesser
{
    public static async Task<ApplicationResponse> ExeptionsThrow (string name)
    {
       throw new Exception(name + "was NOT found");
    }
}
