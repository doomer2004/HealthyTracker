using HealthyTracker.Common.Models.Configs.Abstract;

namespace HealthyTracker.Common.Models.Configs;

public class AuthConfig : ConfigBase
{
    public TimeSpan ConfirmationUrlLifetime { get; set; }
}