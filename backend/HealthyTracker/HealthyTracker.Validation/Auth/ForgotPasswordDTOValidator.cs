using FluentValidation;
using HealthyTracker.Common.Models.DTOs.Auth;

namespace HealthyTracker.Validation.Auth;

public class ForgotPasswordDTOValidator : AbstractValidator<ForgotPasswordDTO>
{
    public ForgotPasswordDTOValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}