using System.Net;
using System.Net.Http;
using Xunit;

namespace TechTest.Tests.Test002;

/// <summary>
/// TEST_002 — validates the /div endpoint once the candidate has added it.
/// </summary>
public class DivisionTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly HttpClient _client = fixture.CreateClient();

    [Theory]
    [InlineData("15",  "3",  "5.00")]
    [InlineData("10",  "4",  "2.50")]
    [InlineData("7",   "2",  "3.50")]
    [InlineData("100", "10", "10.00")]
    public async Task Divide_Returns_Correct_Result(string a, string b, string expected)
    {
        var response = await _client.GetAsync($"/div?a={a}&b={b}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Divide_By_Zero_Returns_400()
    {
        var response = await _client.GetAsync("/div?a=10&b=0");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Divide_Missing_Parameter_Returns_400()
    {
        var response = await _client.GetAsync("/div?a=10");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Divide_Invalid_Parameter_Returns_400()
    {
        var response = await _client.GetAsync("/div?a=foo&b=3");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
