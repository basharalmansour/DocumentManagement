using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Vehicles.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Vehicles.Validators;
public class AddVehicleTemplateCommandValidator : AbstractValidator<CreateVehicleTemplateCommand>
{
    public AddVehicleTemplateCommandValidator()
    {
        RuleFor(x => x.Name).Must((obj, domain) => ValidateMultiLanguage(obj.Name, 64)).WithMessage("Name Must be between 1 and 64 character");
    }

    private bool ValidateMultiLanguage(LanguageString multiLanguageObject, int length)
    {
        return !multiLanguageObject.Any(x => x.Value.Length > length);
    }
}
