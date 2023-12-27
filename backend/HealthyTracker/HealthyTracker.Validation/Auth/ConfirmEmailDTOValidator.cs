using FluentValidation;
using HealthyTracker.Common.Models.DTOs.Auth;

namespace HealthyTracker.Validation.Auth;

public class ConfirmEmailDTOValidator : AbstractValidator<ConfirmEmailDTO>
{
    public ConfirmEmailDTOValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Url)
            .NotEmpty();
    }
}