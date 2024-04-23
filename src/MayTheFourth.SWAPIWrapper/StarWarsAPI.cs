using MayTheFourth.SWAPIWrapper.Models;
using System.Text.Json;

namespace MayTheFourth.SWAPIWrapper
{
    public class StarWarsAPI : IStarWarsAPI
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public StarWarsAPI()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://swapi.py4e.com/api/");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<StarWarsListResponse<StarWarsCharacter>?> GetAllCharactersAsync(int page = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"people/?={page}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsListResponse<StarWarsCharacter>>(json, _jsonOptions);
        }

        public async Task<StarWarsCharacter?> GetCharacterAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"people/{id}/");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsCharacter>(json, _jsonOptions);
        }

        public async Task<StarWarsListResponse<StarWarsPlanet>?> GetAllPlanetsAsync(int page = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"planets/?={page}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsListResponse<StarWarsPlanet>>(json, _jsonOptions);
        }

        public async Task<StarWarsPlanet?> GetPlanetAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"planets/{id}/");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsPlanet>(json, _jsonOptions);
        }

        public async Task<StarWarsListResponse<StarWarsFilm>?> GetAllFilmsAsync(int page = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"films/?={page}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsListResponse<StarWarsFilm>>(json, _jsonOptions);
        }

        public async Task<StarWarsFilm?> GetFilmAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"films/{id}/");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsFilm>(json, _jsonOptions);
        }

        public async Task<StarWarsListResponse<StarWarsSpecies>?> GetAllSpeciesAsync(int page = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"species/?={page}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsListResponse<StarWarsSpecies>>(json, _jsonOptions);
        }

        public async Task<StarWarsSpecies?> GetSpeciesAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"species/{id}/");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var species = JsonSerializer.Deserialize<StarWarsSpecies>(json, _jsonOptions);

            return species;
        }

        public async Task<StarWarsListResponse<StarWarsVehicle>?> GetAllVehiclesAsync(int page = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"vehicles/?={page}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsListResponse<StarWarsVehicle>>(json, _jsonOptions);
        }

        public async Task<StarWarsVehicle?> GetVehicleAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"vehicles/{id}/");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsVehicle>(json, _jsonOptions);
        }

        public async Task<StarWarsListResponse<StarWarsStarship>?> GetAllStarshipsAsync(int page = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"starships/?={page}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsListResponse<StarWarsStarship>>(json, _jsonOptions);
        }

        public async Task<StarWarsStarship?> GetStarshipAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"starships/{id}/");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StarWarsStarship>(json, _jsonOptions);
        }

    }
}
