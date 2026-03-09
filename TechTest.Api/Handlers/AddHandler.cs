using TechTest.Api.Domain;
using TechTest.Api.Utilities;

namespace TechTest.Api.Handlers;

public static class AddHandler
{
    public static async Task Handle(HttpContext context, IMathService mathService)
    {

        if (!QueryParser.TryParseParameters(context, out var a, out var b, out var error))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(error!);
            return;
        }

        var result = mathService.Add(a, b);
        await context.Response.WriteAsync($"{result:F2}");
    }
}
