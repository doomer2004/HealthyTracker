using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class AlreadyExistsErrorDTO : ErrorDto
{
    public AlreadyExistsErrorDTO(string message) : base(ErrorCode.AlreadyExists, message)
    {
    }
}