namespace HealthyTracker.BLL.Extensions;

public static class ValueOrNull
{
    public static float ToFloat(this float? value)
    {
        if (value == null)
        {
            return 0;
        }
        return value.Value;
    }
}