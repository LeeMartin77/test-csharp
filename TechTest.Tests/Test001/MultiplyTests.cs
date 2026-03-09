using System.Net;
using System.Net.Http;
using Xunit;

namespace TechTest.Tests.Test001;

/// <summary>
/// TEST_001 — validates the /mul endpoint once the candidate has fixed the bug.
/// </summary>
public class MultiplyTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly HttpClient _client = fixture.CreateClient();

    [Theory]
    [InlineData("5",   "3",   "15.00")]
    [InlineData("4",   "7",   "28.00")]
    [InlineData("10",  "10",  "100.00")]
    [InlineData("2.5", "4",   "10.00")]
    [InlineData("0",   "99",  "0.00")]
    public async Task Multiply_Returns_Correct_Result(string a, string b, string expected)
    {
        var response = await _client.GetAsync($"/mul?a={a}&b={b}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Multiply_Missing_Parameter_Returns_400()
    {
        var response = await _client.GetAsync("/mul?a=5");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Multiply_Invalid_Parameter_Returns_400()
    {
        var response = await _client.GetAsync("/mul?a=foo&b=3");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
