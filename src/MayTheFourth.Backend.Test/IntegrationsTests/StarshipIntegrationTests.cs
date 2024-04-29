using System.ComponentModel;
using System.Net;
using System.Text.Json;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MayTheFourth.Test;

[DisplayName("Starship Integration Tests v1")]
public class StarshipIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private const string route = "v1/Starships";

    public StarshipIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact(DisplayName = "Get Starships - Returns Success Status Code")]
    [Trait("IntegrationTest", "Starship")]
    public async Task GetStarship_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"{route}");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact(DisplayName = "Get Starship By Id - Returns Success Status Code")]
    [Trait("IntegrationTest", "Starship")]
    public async Task GetStarshipById_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"{route}/1");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var movie = JsonSerializer.Deserialize<Starship>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        Assert.NotNull(movie);
        Assert.Equal(1, movie.Id);
    }

    [Fact(DisplayName = "Get Starship By Id - Returns Not Found Status Code")]
    [Trait("IntegrationTest", "Starship")]
    public async Task GetStarshipById_ReturnsNotFoundStatusCode()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"{route}/{int.MaxValue}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Empty(content);
    }
}
