using TechTest.Api.Domain;
using TechTest.Api.Utilities;

namespace TechTest.Api.Handlers;

public static class MultiplyHandler
{
    public static async Task Handle(HttpContext context, IMathService mathService)
    {
    
        if (QueryParser.TryParseParameters(context, out var a, out var b, out var error))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(error!);
        }

        var result = mathService.Multiply(a, b);
        await context.Response.WriteAsync($"{result:F2}");
    }
}
