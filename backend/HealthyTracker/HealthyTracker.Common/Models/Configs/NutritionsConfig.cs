using HealthyTracker.Common.Models.Configs.Abstract;

namespace HealthyTracker.Common.Models.Configs;

public class NutritionsConfig : ConfigBase
{
    public string AppId { get; set; } = string.Empty;
    public string AppKey { get; set; } = string.Empty;
}