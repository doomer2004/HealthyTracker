using HealthyTracker.Email.Models.Base;

namespace HealthyTracker.Email.Models;

public class EmailConfirmationMessage : EmailMessageBase
{
    public override string Subject => "Email Confirmation";
    public override string TemplateName => nameof(EmailConfirmationMessage);
    public string Url { get; set; } = string.Empty;
}