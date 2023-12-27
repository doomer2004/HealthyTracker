﻿namespace HealthyTracker.Common.Models.DTOs.Auth;

public class ResetPasswordDTO
{  
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}