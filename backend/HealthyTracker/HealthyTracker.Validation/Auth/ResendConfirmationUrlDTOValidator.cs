using FluentValidation;
using HealthyTracker.Common.Models.DTOs.Auth;

namespace HealthyTracker.Validation.Auth;

public class ResendConfirmationUrlDTOValidator : AbstractValidator<ResendConfirmationUrlDTO>
{
    public ResendConfirmationUrlDTOValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}