using FluentValidation;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Validation.Utility;

namespace HealthyTracker.Validation.Config;

public class AuthConfigValidator : ConfigValidatorBase<AuthConfig>
{
    public AuthConfigValidator()
    {
        RuleFor(x => x.ConfirmationUrlLifetime)
            .NotEmpty()
            .GreaterThan(TimeSpan.Zero);
    }
}