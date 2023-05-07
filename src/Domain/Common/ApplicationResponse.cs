using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common;

public class ApplicationResponse<T>
{
    public bool IsError { get; set; }
    public string Message { get; set; }
    public T Result { get; set; }
    public ApplicationResponse(Exception e)
    {
        IsError = true;
        Message = e.Message;
    }
    public ApplicationResponse(T obj)
    {
        IsError = false;
        Result = obj;
    }
}