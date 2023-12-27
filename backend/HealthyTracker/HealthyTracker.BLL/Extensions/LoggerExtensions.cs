using HealthyTracker.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HealthyTracker.BLL.Extensions;

public static class LoggerExtensions
{
    public static void LogIdentityError<T>(this ILogger<T> logger, User user, IdentityResult result)
    {
        if (result.Succeeded)
        {
            return;
        }

        var errors = string.Join("\n", result.Errors.Select(ex => ex.Description));
        logger.LogError("User with id {1} has following errors:\n{2}", user.Id, errors);
    }
}