using System.Net;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Extensions;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;

[ApiController]
[Route("api/google-auth")]
public class GoogleAuthController : ControllerBase
{
    private readonly IGoogleAuthService _googleAuthService;
    
    public GoogleAuthController(IGoogleAuthService googleAuthService)
    {
        _googleAuthService = googleAuthService;
    }
    
    [HttpPost("sign-up")]
    [ProducesResponseType(typeof(Either<ErrorDto, AuthSuccessDTO>), (int)HttpStatusCode.OK)]
    
    public async Task<IActionResult> SignUp([FromHeader(Name = "Authorization-Code")] string authorizationCode)
    {
        var result = await _googleAuthService.SignUpAsync(authorizationCode);
        return result.ToActionResult();
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(typeof(Either<ErrorDto, AuthSuccessDTO>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SignIn([FromHeader(Name = "Authorization-Code")] string authorizationCode)
    {
        var result = await _googleAuthService.SignInAsync(authorizationCode);
        return result.ToActionResult();
    }
}