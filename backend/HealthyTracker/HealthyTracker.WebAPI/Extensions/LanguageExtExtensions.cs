using HealthyTracker.Common.Models.DTOs.Error;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.Extensions;

public static class LanguageExtExtensions
{
    public static IActionResult ToActionResult<T>(this Either<ErrorDto, T> either)
    {
        return either.Match<IActionResult>(
            Left: error => new BadRequestObjectResult(error),
            Right: x => new OkObjectResult(x)
        );
    }

    public static IActionResult ToActionResult(this Option<ErrorDto> either)
    {
        return either.Match<IActionResult>(
            Some: error => new BadRequestObjectResult(error),
            None: () => new NoContentResult()
        );
    }
}