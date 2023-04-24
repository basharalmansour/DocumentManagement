using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.DocumentsTemplate.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.DocumentsTemplate.Validators;
public class AddDocumentTemplateCommandValidator: AbstractValidator<CreateDocumentTemplateCommand>
{
    public AddDocumentTemplateCommandValidator()
    {
        RuleFor(x => x.Name).Must((obj, domain)=>ValidateMultiLanguage(obj.Name, 64)).WithMessage("Name Must be between 1 and 64 character");
        RuleFor(x => x.DocumentTemplateFileTypes.Count).GreaterThan(0);
    }

    public bool ValidateMultiLanguage(LanguageString multiLanguageObject, int length)
    {
        return !multiLanguageObject.Any(x => x.Value.Length > length);
    }
}
