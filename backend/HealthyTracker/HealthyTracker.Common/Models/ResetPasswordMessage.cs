using HealthyTracker.Common.Models.Base;

namespace HealthyTracker.Common.Models;

public class ResetPasswordMessage : EmailMessageBase
{
    public override string Subject => "Reset Password";
    public override string TemplateName => nameof(ResetPasswordMessage);
    public string UserName { get; set; } = string.Empty;
    public string ResetPasswordUrl { get; set; } = string.Empty;
}