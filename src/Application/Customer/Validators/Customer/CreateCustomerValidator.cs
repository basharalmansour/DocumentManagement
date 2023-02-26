    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Customer.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Customer.Validators.Customer;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
   
        RuleFor(x=>x.Customer.Surname).NotEmpty().NotNull().MaximumLength(50);
        RuleFor(x => x.Customer.GenderId).NotNull();
        RuleFor(x => x.Customer.Email).EmailAddress();
        RuleFor(x => x.Customer.PhoneNumber).NotEmpty().NotNull();
        RuleFor(x=>x.Customer.IdentityNumber).NotEmpty().NotNull();
        RuleFor(x=>x.Customer.Password).NotEmpty().NotNull();
        RuleFor(x=>x.Customer.CountryPhoneCode).NotEmpty().NotNull(); 
        RuleFor(x=>x.Customer.AgreementTextAccept).Equal(true);
        RuleFor(x=>x.Customer.KvkkPermissionAccept).Equal(true);
        RuleFor(x => x.Customer.PhoneNumber)
            .Length(10)
            .When(x => x.Customer.CountryPhoneCode.Equals("+90"));
    }
}
