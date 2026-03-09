using Microsoft.AspNetCore.Mvc.Testing;

namespace TechTest.Tests;

/// <summary>
/// Shared WebApplicationFactory fixture — starts the real API in-memory.
/// </summary>
public class ApiFixture : WebApplicationFactory<Program>
{
    // No overrides needed; defaults boot the app exactly as written.
}
