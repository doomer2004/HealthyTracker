using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace HealthyTracker.Validation;

public interface IValidatorService
{
    FluentValidation.Results.ValidationResult Validate<T>(T instance);
    Task<ValidationResult> ValidateAsync<T>(T instance, CancellationToken cancellationToken = default);
}