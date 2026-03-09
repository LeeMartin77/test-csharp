using TechTest.Api.Domain;
using TechTest.Api.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMathService, MathService>();

var app = builder.Build();

app.MapGet("/ping", PingHandler.Handle);
app.MapGet("/add",  (HttpContext ctx, IMathService svc) => AddHandler.Handle(ctx, svc));
app.MapGet("/sub",  (HttpContext ctx, IMathService svc) => SubtractHandler.Handle(ctx, svc));
app.MapGet("/mul",  (HttpContext ctx, IMathService svc) => MultiplyHandler.Handle(ctx, svc));

app.Run();

// Partial class so WebApplicationFactory can find the entry point in tests
public partial class Program { }
