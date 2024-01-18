using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class NotFoundErrorDTO : ErrorDto
{
    public NotFoundErrorDTO(string message) : base(ErrorCode.NotFound, message) { }
}