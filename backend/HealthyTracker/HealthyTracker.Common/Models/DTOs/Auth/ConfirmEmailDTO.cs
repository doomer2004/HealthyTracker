namespace HealthyTracker.Common.Models.DTOs.Auth;

public class ConfirmEmailDTO
{
    public Guid UserId { get; set; }
    public string Url { get; set; }
}