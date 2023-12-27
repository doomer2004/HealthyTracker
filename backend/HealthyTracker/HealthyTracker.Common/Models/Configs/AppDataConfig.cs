using HealthyTracker.Common.Models.Configs.Abstract;

namespace HealthyTracker.Common.Models.Configs;

public class AppDataConfig : ConfigBase
{
    public string AppDataPath { get; set; } = string.Empty;
    public string LogDirectory { get; set; } = string.Empty;
    public string WebRootPath { get; set; } = string.Empty;
    public string UploadsDirectory { get; set; } = string.Empty;
    public string UsersDirectory { get; set; } = string.Empty;
    public string DefaultDirectory { get; set; } = string.Empty;
    public Dictionary<string, string> AllowedImages { get; set; } = new();
    public string AvatarFileName { get; set; } = string.Empty;
    public string DefaultAvatarFileExtension { get; set; } = string.Empty;
    public string UserAvatarDirectoryPath => Path.Combine(WebRootPath, UploadsDirectory, UsersDirectory);
    public string DefaultUserAvatarPath => Path.Combine(WebRootPath, UploadsDirectory, DefaultDirectory, UsersDirectory, AvatarFileName + DefaultAvatarFileExtension);
}