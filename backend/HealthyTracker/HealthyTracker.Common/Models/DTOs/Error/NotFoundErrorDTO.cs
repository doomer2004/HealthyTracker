using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class NotFoundErrorDTO : ErrorDTO
{
    public NotFoundErrorDTO(string message) : base(ErrorCode.NotFound, message) { }
}