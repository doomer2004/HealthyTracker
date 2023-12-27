using FluentValidation;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Validation.Utility;

namespace HealthyTracker.Validation.Config;

public class JwtConfigValidator : ConfigValidatorBase<JwtConfig>
{
    public JwtConfigValidator()
    {
        RuleFor(x => x.Secret)
            .NotEmpty();

        RuleFor(x => x.Issuer)
            .NotEmpty();

        RuleFor(x => x.Audience)
            .NotEmpty();

        RuleFor(x => x.AccessTokenLifetime)
            .NotEmpty()
            .GreaterThan(TimeSpan.Zero);

        RuleFor(x => x.RefreshTokenLifetime)
            .NotEmpty()
            .GreaterThan(TimeSpan.Zero);
    }
}