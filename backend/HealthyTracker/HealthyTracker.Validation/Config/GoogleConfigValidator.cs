using FluentValidation;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Validation.Utility;

namespace HealthyTracker.Validation.Config;

public class GoogleConfigValidator : ConfigValidatorBase<GoogleConfig>
{
    public GoogleConfigValidator()
    {
        RuleFor(x => x.ClientSecret)
            .NotEmpty();

        RuleFor(x => x.ClientId)
            .NotEmpty();

        RuleFor(x => x.RedirectUri)
            .NotEmpty();

        RuleFor(x => x.ClockTolerance)
            .NotEmpty();
    }
}