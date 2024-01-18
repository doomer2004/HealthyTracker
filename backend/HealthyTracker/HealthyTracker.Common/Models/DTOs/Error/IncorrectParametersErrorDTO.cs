using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class IncorrectParametersErrorDTO : ErrorDto
{
    public IncorrectParametersErrorDTO(string message) : base(ErrorCode.IncorrectParameters, message)
    {
    }
}