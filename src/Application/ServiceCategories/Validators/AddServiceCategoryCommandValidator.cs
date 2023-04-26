using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.ServiceCategories.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.ServiceCategories.Validators;
public  class AddServiceCategoryCommandValidator: AbstractValidator<CreateServiceCategoryCommand>
{
    public AddServiceCategoryCommandValidator()
    {
        RuleFor(x => x.Name).Must((obj, domain) => ValidateMultiLanguage(obj.Name, 64)).WithMessage("Name Must be between 1 and 64 character");
        RuleFor(x => x.MaxPersonnelCount).GreaterThan(0);
        RuleFor(x => x.MaxServiceDuration).GreaterThan(0);
    }

    private bool ValidateMultiLanguage(LanguageString multiLanguageObject, int length)
    {
        return !multiLanguageObject.Any(x => x.Value.Length > length);
    }
}
