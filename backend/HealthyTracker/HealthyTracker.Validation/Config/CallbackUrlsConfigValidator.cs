using FluentValidation;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Validation.Extensions;
using HealthyTracker.Validation.Utility;

namespace HealthyTracker.Validation.Config;

public class CallbackUrlsConfigValidator : ConfigValidatorBase<CallbackUrisConfig>
{
    public CallbackUrlsConfigValidator()
    {
        RuleFor(x => x.ResetPasswordUriTemplate)
            .NotEmpty()
            .HasFormatParams(2);
    }
}