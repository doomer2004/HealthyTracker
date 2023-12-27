using HealthyTracker.Common.Models.Configs.Abstract;

namespace HealthyTracker.Common.Models.Configs;

public class CallbackUrisConfig : ConfigBase
{
    public string ResetPasswordUriTemplate { get; set; } = string.Empty;
}