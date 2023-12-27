using FluentValidation;
using HealthyTracker.Common.Models.DTOs.Auth;

namespace HealthyTracker.Validation.Auth;

public class RefreshTokenDTOValidator : AbstractValidator<RefreshTokenDTO>
{
    public RefreshTokenDTOValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotEmpty();

        RuleFor(x => x.RefreshToken)
            .NotEmpty();
    }
}