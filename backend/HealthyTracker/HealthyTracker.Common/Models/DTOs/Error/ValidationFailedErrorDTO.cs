using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class ValidationFailedErrorDTO : ErrorDTO
{
    public IDictionary<string, string[]> Body { get; set; }
    public ValidationFailedErrorDTO(IDictionary<string, string[]> body) : base(ErrorCode.ValidationFailed, "Validation failed")
    {
        Body = body;
    }
}