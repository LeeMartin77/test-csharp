namespace TechTest.Api.Utilities;

public static class QueryParser
{
    /// <summary>
    /// Parses the query parameters "a" and "b" as doubles.
    /// Returns false if either is missing or invalid.
    /// </summary>
    public static bool TryParseParameters(HttpContext context, out double a, out double b, out string? error)
    {
        a = 0; b = 0; error = null;

        if (!context.Request.Query.TryGetValue("a", out var raw) || string.IsNullOrEmpty(raw))
        {
            error = "missing parameter: a";
            return false;
        }

        if (!double.TryParse(raw, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out a))
        {
            error = "invalid parameter: a";
            return false;
        }

        if (!context.Request.Query.TryGetValue("b", out var raw2) || string.IsNullOrEmpty(raw2))
        {
            error = "missing parameter: b";
            return false;
        }

        if (!double.TryParse(raw2, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out b))
        {
            error = "invalid parameter: b";
            return false;
        }
        return true;
    }
}
