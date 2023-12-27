namespace HealthyTracker.Common.Models.DTOs.User;

public class UserDTO
{
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public bool HasPassword { get; set; }
}