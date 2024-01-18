using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class ExpiredErrorDTO : ErrorDto
{
    public ExpiredErrorDTO(string message) : base(ErrorCode.ExpiredError, message)
    {
    }
}