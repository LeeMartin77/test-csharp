using System.Net;
using System.Net.Http;
using Xunit;

namespace TechTest.Tests.Core;

/// <summary>
/// Core tests — validates the base endpoints (ping, add, subtract) that are
/// provided to candidates as working examples.
/// </summary>
public class CoreTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly HttpClient _client = fixture.CreateClient();

    [Fact]
    public async Task Ping_Returns_Pong()
    {
        var response = await _client.GetAsync("/ping");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Equal("pong", body);
    }

    [Theory]
    [InlineData("10", "5",   "15.00")]
    [InlineData("15", "25",  "40.00")]
    [InlineData("3.5", "2.1", "5.60")]
    public async Task Add_Returns_Correct_Result(string a, string b, string expected)
    {
        var response = await _client.GetAsync($"/add?a={a}&b={b}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, await response.Content.ReadAsStringAsync());
    }

    [Theory]
    [InlineData("10", "3",  "7.00")]
    [InlineData("20", "8",  "12.00")]
    [InlineData("5",  "5",  "0.00")]
    public async Task Subtract_Returns_Correct_Result(string a, string b, string expected)
    {
        var response = await _client.GetAsync($"/sub?a={a}&b={b}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Add_Missing_Parameter_Returns_400()
    {
        var response = await _client.GetAsync("/add?a=5");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Subtract_Invalid_Parameter_Returns_400()
    {
        var response = await _client.GetAsync("/sub?a=foo&b=3");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
