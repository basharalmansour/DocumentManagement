using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Customer.Queries;
using FluentValidation;

namespace CleanArchitecture.Application.Customer.Validators.Customer;

public class CheckCustomerByQueryValidator : AbstractValidator<CheckCustomerByQuery>
{
    public CheckCustomerByQueryValidator()
    {
        RuleFor(x => x.IdentityNumber).Length(11).NotEmpty().NotNull();
        RuleFor(x => x.MobileNo).Length(10).NotEmpty().NotNull();
        RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
    }
}
