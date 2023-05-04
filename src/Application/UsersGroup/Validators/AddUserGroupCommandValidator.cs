using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.UsersGroup.Commands;
using CleanArchitecture.Application.VehicleTemplates.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.UsersGroup.Validators;
public class AddUserGroupCommandValidator : AbstractValidator<CreateUserGroupCommand>
{
    public AddUserGroupCommandValidator()
    {
        RuleFor(x => x.Name).Must((obj, domain) => ValidateMultiLanguage(obj.Name, 64)).WithMessage("Name Must be between 1 and 64 character");
        RuleFor(x => x.PersonnelIds.Count).GreaterThan(1).WithMessage("User group must contain more than one personnel");
    }

    private bool ValidateMultiLanguage(LanguageString multiLanguageObject, int length)
    {
        return !multiLanguageObject.Any(x => x.Value.Length > length);
    }
}