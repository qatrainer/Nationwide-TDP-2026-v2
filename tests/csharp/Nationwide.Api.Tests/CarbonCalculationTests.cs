// NW TDP 2026 v2
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class CarbonCalculationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public CarbonCalculationTests(WebApplicationFactory<Program> factory) => _client = factory.CreateClient();

    [Fact]
    public async Task Calculate_returns_success_for_valid_spending()
    {
        var response = await _client.PostAsJsonAsync("/calculate", new { spending = new[] { new { category = "Travel", amount = 25 } } });
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("totalCarbonKg", await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Calculate_rejects_negative_spending()
    {
        var response = await _client.PostAsJsonAsync("/calculate", new { spending = new[] { new { category = "Travel", amount = -1 } } });
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
