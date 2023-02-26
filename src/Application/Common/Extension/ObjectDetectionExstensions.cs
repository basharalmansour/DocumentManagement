using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Extension;

public static class ObjectDetectionExstensions
{
    public static bool IsList(this object @object)
    {
        if (@object == null) return false;
        return @object.GetType() == typeof(IList<>) &&
               @object.GetType().IsGenericType &&
               @object.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
    }
    public static bool ISDictionary(this object @object)
    {
        if (@object == null) return false;
        return @object.GetType().IsGenericType &&
               @object.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
    }
}
