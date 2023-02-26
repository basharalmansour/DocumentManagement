using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.Customer;

public class CreateIntegrationUserResulDto
{
    public string Id { get; set; }
    public MembershipType MembershipType { get; set; }
}
