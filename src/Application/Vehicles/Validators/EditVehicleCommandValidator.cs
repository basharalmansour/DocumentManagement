using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Vehicles.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Vehicles.Validators;
public class EditVehicleCommandValidator : AbstractValidator<EditVehicleCommand>
{
    public EditVehicleCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(64).WithMessage("Name Must be between 1 and 64 character");
    }
}
