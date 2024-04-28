using System.ComponentModel;
using System.Net;
using System.Text.Json;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MayTheFourth.Test;

[DisplayName("Film Integration Tests v1")]
public class FilmIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private const string route = "v1/films";

    public FilmIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact(DisplayName = "Get Films - Returns Success Status Code")]
    [Trait("IntegrationTest", "Film")]
    public async Task GetFilm_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"{route}");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact(DisplayName = "Get Film By Id - Returns Success Status Code")]
    [Trait("IntegrationTest", "Film")]
    public async Task GetFilmById_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"{route}/1");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var movie = JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        Assert.NotNull(movie);
        Assert.Equal(1, movie.Id);
    }

    [Fact(DisplayName = "Get Film By Id - Returns Not Found Status Code")]
    [Trait("IntegrationTest", "Film")]
    public async Task GetFilmById_ReturnsNotFoundStatusCode()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"{route}/{int.MaxValue}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Empty(content);
    }
}
