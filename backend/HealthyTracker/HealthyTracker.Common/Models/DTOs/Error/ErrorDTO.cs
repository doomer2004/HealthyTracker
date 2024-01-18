using HealthyTracker.Common.Enums;

namespace HealthyTracker.Common.Models.DTOs.Error;

public class ErrorDto
{
    public string Message { get; set; }
    public ErrorCode Error { get; set; }
    public ErrorDto(ErrorCode error, string message)
    {
        Message = message;
        Error = error;
    }
}