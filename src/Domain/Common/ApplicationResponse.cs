using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common;
public class ApplicationResponse
{
    public bool IsError { get; set; }
    public string Message { get; set; }
    public object Result { get; set; }
    public ApplicationResponse(Exception e)
    {
        IsError = true;
        Message = e.Message;
    }
    public ApplicationResponse(object obj)
    {
        IsError = false;
        Result = obj;
    }
}
