using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class IdentityErrorDTO : ErrorDTO
{
    public IdentityErrorDTO(string message) : base(ErrorCode.IdentityError, message)
    {
    }
}