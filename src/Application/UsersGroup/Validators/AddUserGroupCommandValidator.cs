using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.UsersGroup.Commands;
using CleanArchitecture.Application.Vehicles.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.UsersGroup.Validators;
public class AddUserGroupCommandValidator : AbstractValidator<CreateUserGroupCommand>
{
    public AddUserGroupCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(64).WithMessage("Name must be between 1 and 64 character");
        RuleFor(x => x.PersonnelIds.Count).GreaterThan(1).WithMessage("User group must contain more than one personnel");
        RuleFor(x => x.PersonnelIds).NotEmpty().WithMessage("User group must contain more than one personnel");
    }
}