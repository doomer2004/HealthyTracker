using HealthyTracker.Common.Models.Configs.Abstract;

namespace HealthyTracker.Common.Models.Configs;

public class UrisConfig : ConfigBase
{
    public string ResetPasswordUriTemplate { get; set; } = string.Empty;
    public string ConfirmEmailUriTemplate { get; set; } = string.Empty;
}