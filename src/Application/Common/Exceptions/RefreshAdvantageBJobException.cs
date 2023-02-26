using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Exceptions;

public class RefreshAdvantageBJobException : Exception
{
    public RefreshAdvantageBJobException()
    {
    }

    public RefreshAdvantageBJobException(string message) : base(message)
    {
    }

    public RefreshAdvantageBJobException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected RefreshAdvantageBJobException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
