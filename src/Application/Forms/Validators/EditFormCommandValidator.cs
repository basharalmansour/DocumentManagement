using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Forms.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Forms.Validators;
public class EditFormCommandValidator : AbstractValidator<EditFormCommand>
{
    public EditFormCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(64).WithMessage("Name Must be between 1 and 64 character");
        RuleFor(x => x.Questions).Must(NamesCheck).WithMessage("All Questions must have text");
        RuleFor(x => x.Questions.Count).GreaterThan(0);
    }

    private bool NamesCheck(List<AddQuestionRequest> request)
    {
        return !request.Any(question => question.Name == null);
    }
}

