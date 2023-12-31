﻿using HealthyTracker.Email.Models.Base;

namespace HealthyTracker.Email.Models;

public class ResetPasswordMessage : EmailMessageBase
{
    public override string Subject => "Reset Password";
    public override string TemplateName => nameof(ResetPasswordMessage);
    public string UserName { get; set; } = string.Empty;
    public string ResetPasswordUrl { get; set; } = string.Empty;
}