using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.ServiceCategories.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.ServiceCategories.Validators;
public class EditServiceCategoryCommandValidator : AbstractValidator<EditServiceCategoryCommand>
{
    public EditServiceCategoryCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(64).WithMessage("Name Must be between 1 and 64 character");
        RuleFor(x => x.MaxPersonnelCount).GreaterThan(0);
        RuleFor(x => x.MaxServiceDuration).GreaterThan(0);
    }
}
