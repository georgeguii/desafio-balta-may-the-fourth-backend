using System.ComponentModel;
using System.Net;
using System.Text.Json;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MayTheFourth.Test;

[DisplayName("Character Integration Tests v1")]
public class CharacterIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private const string route = "v1/Characters";

    public CharacterIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact(DisplayName = "Get Characters - Returns Success Status Code")]
    [Trait("IntegrationTest", "Character")]
    public async Task GetCharacter_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"{route}");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact(DisplayName = "Get Character By Id - Returns Success Status Code")]
    [Trait("IntegrationTest", "Character")]
    public async Task GetCharacterById_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"{route}/1");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var movie = JsonSerializer.Deserialize<Character>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        Assert.NotNull(movie);
        Assert.Equal(1, movie.Id);
    }

    [Fact(DisplayName = "Get Character By Id - Returns Not Found Status Code")]
    [Trait("IntegrationTest", "Character")]
    public async Task GetCharacterById_ReturnsNotFoundStatusCode()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"{route}/{int.MaxValue}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Empty(content);
    }
}
