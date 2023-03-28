﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Forms.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Forms.Validators;
public  class AddFormCommandValidator : AbstractValidator<CreateFormCommnad>
{
    public AddFormCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(64).WithMessage("Name Must be between 1 and 64 character");
        RuleFor(x => x.Questions.Count).GreaterThan(0);
    }
}