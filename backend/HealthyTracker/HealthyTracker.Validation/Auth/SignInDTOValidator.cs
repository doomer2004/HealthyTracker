using FluentValidation;
using HealthyTracker.Common.Models.DTOs.Auth;

namespace HealthyTracker.Validation.Auth;

public class SignInDTOValidator : AbstractValidator<SignInDTO>
{
    public SignInDTOValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}