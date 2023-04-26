using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Forms.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Forms.Validators;
public class EditFormCommandValidator : AbstractValidator<EditFormCommand>
{
    public EditFormCommandValidator()
    {
        RuleFor(x => x.Name).Must((obj, domain) => ValidateMultiLanguage(obj.Name, 64)).WithMessage("Name Must be between 1 and 64 character");
        RuleFor(x => x.Questions).Must(NamesCheck).WithMessage("All Questions must have text");
        RuleFor(x => x.Questions.Count).GreaterThan(0);
    }

    private bool ValidateMultiLanguage(LanguageString multiLanguageObject, int length)
    {
        return !multiLanguageObject.Any(x => x.Value.Length > length);
    }

    private bool NamesCheck(List<CreateQuestionRequest> request)
    {
        return !request.Any(question => question.Name == null);
    }
}

