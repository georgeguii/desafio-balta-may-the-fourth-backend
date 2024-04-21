using System.Net;
using System.Text.Json;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc.Testing;

public class FilmIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public FilmIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetFilm_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Film");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetFilmById_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/film/1");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var movie = JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        Assert.NotNull(movie);
        Assert.Equal(1, movie.Id);
    }

    [Fact]
    public async Task GetFilmById_ReturnsNotFoundStatusCode()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"/film/{int.MaxValue}"); ;

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Empty(content);
    }
}
