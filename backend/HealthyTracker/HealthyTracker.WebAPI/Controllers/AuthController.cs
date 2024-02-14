using System.Net;
using AutoMapper;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.User;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Extensions;
using HealthyTracker.Validation;
using HealthyTracker.Validation.Extensions;
using LanguageExt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IEmailConfirmationService _emailConfirmationService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IPasswordService _passwordService;
    private readonly IValidatorService _validator;
    private UserManager<User> _userManager;
    private readonly IMapper _mapper;
    
    public AuthController(IAuthService authService,
        IEmailConfirmationService emailConfirmationService,
        IRefreshTokenService refreshTokenService,
        IPasswordService passwordService,
        IValidatorService validator,
        UserManager<User> userManager, 
        IMapper mapper)
    {
        _authService = authService;
        _emailConfirmationService = emailConfirmationService;
        _refreshTokenService = refreshTokenService;
        _passwordService = passwordService;
        _validator = validator;
        _userManager = userManager;
        _mapper = mapper;
    }
    
    [HttpPost("sign-up")]
    [ProducesResponseType(typeof(Either<ErrorDto, SignUpResponseDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationFailedErrorDTO), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SignUp(SignUpDTO dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.ToErrorDTO());
        }

        var result = await _authService.SignUpAsync(dto);
        return result.ToActionResult();
    }

    [HttpGet("me")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> Me()
    {
        var userId = HttpContext.GetUserId();
        var user = await _userManager.FindByIdAsync(userId.ToString());
        var userDto = _mapper.Map<UserDTO>(user);
        return Ok(userDto);
    }
    
    [HttpPost("confirm-email")]
    [ProducesResponseType(typeof(ValidationFailedErrorDTO), (int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Either<ErrorDto, AuthSuccessDTO>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailDTO dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.ToErrorDTO());

        var result = await _emailConfirmationService.ConfirmEmailAsync(dto);
        return result.ToActionResult();
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(typeof(Either<ErrorDto, AuthSuccessDTO>), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationFailedErrorDTO), (int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SignIn(SignInDTO dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.ToErrorDTO());

        var result = await _authService.SignInAsync(dto);
        return result.ToActionResult();
    }

    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(Either<ErrorDto, AuthSuccessDTO>), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationFailedErrorDTO), (int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> RefreshToken(RefreshTokenDTO dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.ToErrorDTO());

        var result = await _refreshTokenService.RefreshTokenAsync(dto);
        return result.ToActionResult();
    }

    [HttpPost("resend-confirmation-code")]
    [ProducesResponseType(typeof(ValidationFailedErrorDTO), (int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Either<ErrorDto, AuthSuccessDTO>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> ResendConfirmationUrl(ResendConfirmationUrlDTO dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.ToErrorDTO());

        var result = await _emailConfirmationService.ResendConfirmationCodeAsync(dto);
        return result.ToActionResult();
    }

    [HttpPost("forgot-password")]
    [ProducesResponseType(typeof(ValidationFailedErrorDTO), (int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Option<ErrorDto>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.ToErrorDTO());

        var result = await _passwordService.ForgotPasswordAsync(dto);
        return result.ToActionResult();
    }

    [HttpPost("reset-password")]
    [ProducesResponseType(typeof(ValidationFailedErrorDTO), (int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Option<ErrorDto>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.ToErrorDTO());

        var result = await _passwordService.ResetPasswordAsync(dto);
        return result.ToActionResult();
    }
}