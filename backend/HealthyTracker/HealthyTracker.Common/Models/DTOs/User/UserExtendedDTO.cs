namespace HealthyTracker.Common.Models.DTOs.User;

public class UserExtendedDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool HasPassword { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
}