using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums.VeriSoftEnums;

namespace CleanArchitecture.Application.Common.Dtos.Customer;

public class GetIntegrationCustomerRegisterInfoDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string CardNo { get; set; }
    public string Phone { get; set; }
    public string IdentityNumber { get; set; }
    public VerisoftGender Gender { get; set; }
    public DateTime BirthDate { get; set; }
}
