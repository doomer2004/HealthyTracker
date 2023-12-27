using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class ErrorDTO
{
    public string Massage { get; set; }
    public ErrorCode Error { get; set; }
    public ErrorDTO(ErrorCode error, string message)
    {
        Massage = message;
        Error = error;
    }
}