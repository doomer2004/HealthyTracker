using Microsoft.AspNetCore.Identity;

namespace HealthyTracker.DAL.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string? RefreshToken { get; set; }
    public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
    public string? Avatar { get; set; }
    
    public List<UserRegistration> UserRegistrations { get; set; } = new();
    
}