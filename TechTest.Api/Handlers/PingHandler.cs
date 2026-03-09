namespace TechTest.Api.Handlers;

public static class PingHandler
{
    public static IResult Handle() => Results.Text("pong");
}
