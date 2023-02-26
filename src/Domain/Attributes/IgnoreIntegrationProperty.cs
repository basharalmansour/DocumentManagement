using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,AllowMultiple =false,Inherited =false)]
public class IgnoreIntegrationProperty : Attribute
{
}
