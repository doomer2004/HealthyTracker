using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class ExternalErrorDTO : ErrorDto
{
    public ExternalErrorDTO(string message) : base(ErrorCode.ExternalError, message)
    {
    }
}