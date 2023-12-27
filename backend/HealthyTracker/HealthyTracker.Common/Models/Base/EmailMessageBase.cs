namespace HealthyTracker.Common.Models.Base;

public abstract class EmailMessageBase
{
    public abstract string Subject { get; }
    public abstract string TemplateName  { get; }
}