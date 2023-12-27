using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class ExternalErrorDTO : ErrorDTO
{
    public ExternalErrorDTO(string message) : base(ErrorCode.ExternalError, message)
    {
    }
}