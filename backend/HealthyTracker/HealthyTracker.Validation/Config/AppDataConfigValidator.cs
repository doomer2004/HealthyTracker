using FluentValidation;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Validation.Utility;

namespace HealthyTracker.Validation.Config;

public class AppDataConfigValidator : ConfigValidatorBase<AppDataConfig>
{
    public AppDataConfigValidator()
    {
        RuleFor(x => x.AppDataPath)
            .NotEmpty();

        RuleFor(x => x.LogDirectory)
            .NotEmpty();
    }
}