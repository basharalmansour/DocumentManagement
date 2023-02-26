using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Basket.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Basket.Validators;

public class AddInvoiceCommandValidator : AbstractValidator<AddInvoiceCommand>
{
    public AddInvoiceCommandValidator()
    {
        RuleFor(x=>x.Email).EmailAddress();
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.InvoiceAddress).NotEmpty().NotNull();
        RuleFor(x=>x.TaxNo).NotEmpty().NotNull().When(x=>x.Type =="C");
        RuleFor(x=>x.Taxoffice).NotEmpty().NotNull().When(x => x.Type == "C");
        RuleFor(x => x.Type).Must(x => x == "C" || x == "P").WithMessage("Invalid type");
    }
}
