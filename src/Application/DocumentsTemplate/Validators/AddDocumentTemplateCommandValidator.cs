﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.DocumentsTemplate.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.DocumentsTemplate.Validators;
public class AddDocumentTemplateCommandValidator: AbstractValidator<CreateDocumentTemplateCommand>
{
    public AddDocumentTemplateCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(64).WithMessage("Name Must be between 1 and 64 character");
    }
}
