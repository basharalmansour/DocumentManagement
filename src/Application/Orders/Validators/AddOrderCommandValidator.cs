using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Application.Orders.Commands;
using CleanArchitecture.Domain.Enums;
using FluentValidation;

namespace CleanArchitecture.Application.Orders.Validators;
public class AddOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public AddOrderCommandValidator()
    {
        RuleFor(x => x).Must(ValidateDate).WithMessage("Invalid start and end date");
        RuleFor(x => x).Must(ValidatePresence).WithMessage("Presence has invalid ID");
    }

    private bool ValidatePresence(CreateOrderCommand request)
    {
        if (request.PresencesType == PresencesType.Block || request.PresencesType == PresencesType.Site || request.PresencesType == PresencesType.Zone)
        {
            if (request.GuidPresenceId == null)
                return false;
        }
        else
        {
            if (request.IntegerPresenceId == null)
                return false;
        }
        return true;
    }

    private bool ValidateDate(CreateOrderCommand request)
    {
        if (request.StartDate <= request.EndDate)
            return true;
        else
            return false;
    }
}
