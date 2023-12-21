using Microsoft.AspNetCore.Identity;

namespace HealthyTracker.DAL.Entities;

public class User : IdentityUser<Guid>
{
    public string DisplayName { get; set; } = null!;
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public string? Avatar { get; set; }
    
}