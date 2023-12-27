using FluentValidation.Results;
using HealthyTracker.Common.Models.Configs.Abstract;

namespace HealthyTracker.Validation.Utility;

public interface IConfigValidator
{
    ValidationResult ValidateConfig(ConfigBase config);
    Task<ValidationResult> ValidateConfigAsync(ConfigBase config);
}