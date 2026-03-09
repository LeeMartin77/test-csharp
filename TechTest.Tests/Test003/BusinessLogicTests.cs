using System.Net;
using System.Net.Http;
using Xunit;

namespace TechTest.Tests.Test003;

/// <summary>
/// TEST_003 — validates the /businesslogic endpoint once the candidate has added it.
/// Formula: ((a + b) - c) * d / a
/// </summary>
public class BusinessLogicTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly HttpClient _client = fixture.CreateClient();

    [Theory]
    [InlineData("10", "5", "3", "2",  "2.40")]  // ((10+5)-3)*2/10 = 2.40
    [InlineData("4",  "2", "1", "3",  "3.75")]  // ((4+2)-1)*3/4  = 3.75
    [InlineData("5",  "5", "0", "1",  "2.00")]  // ((5+5)-0)*1/5  = 2.00
    public async Task BusinessLogic_Returns_Correct_Result(
        string a, string b, string c, string d, string expected)
    {
        var response = await _client.GetAsync($"/businesslogic?a={a}&b={b}&c={c}&d={d}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task BusinessLogic_Missing_Parameter_Returns_400()
    {
        var response = await _client.GetAsync("/businesslogic?a=10&b=5&c=3");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task BusinessLogic_Invalid_Parameter_Returns_400()
    {
        var response = await _client.GetAsync("/businesslogic?a=foo&b=5&c=3&d=2");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
