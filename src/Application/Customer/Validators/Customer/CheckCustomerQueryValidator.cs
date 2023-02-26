using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Customer.Queries;
using FluentValidation;

namespace CleanArchitecture.Application.Customer.Validators.Customer;

public class CheckCustomerQueryValidator : AbstractValidator<CheckCustomerQuery>
{
    public CheckCustomerQueryValidator()
    {
        RuleFor(x => x.CardNo).NotEmpty();
        RuleFor(x => x.MobileNo).NotEmpty();
    }
}
