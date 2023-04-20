using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Presences.PresenceGroups.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Validators;
public class EditPresenceGroupCommandValidator : AbstractValidator<EditPresenceGroupCommand>
{
    public EditPresenceGroupCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(64).WithMessage("Name Must be between 1 and 64 character");
        RuleFor(x => x).Must(NotEmpty).WithMessage("New presence group must have one element at least");
    }

    private bool NotEmpty(CreatePresenceGroupCommand presenceGroup)
    {
        var presenceGroupElements = presenceGroup.PresenceGroupAreas.Count + presenceGroup.PresenceGroupBlocks.Count + presenceGroup.PresenceGroupBrands.Count + presenceGroup.presenceGroupCompanies.Count + presenceGroup.PresenceGroupSites.Count + presenceGroup.PresenceGroupUnits.Count + presenceGroup.PresenceGroupZones.Count;
        if (presenceGroupElements >= 1)
            return true;
        else
            return false;
    }
}