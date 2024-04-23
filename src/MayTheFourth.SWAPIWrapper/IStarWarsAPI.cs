using MayTheFourth.SWAPIWrapper.Models;

namespace MayTheFourth.SWAPIWrapper
{
    public interface IStarWarsAPI
    {
        Task<StarWarsListResponse<StarWarsCharacter>?> GetAllCharactersAsync(int page = 1);
        Task<StarWarsCharacter?> GetCharacterAsync(int id);

        Task<StarWarsListResponse<StarWarsPlanet>?> GetAllPlanetsAsync(int page = 1);
        Task<StarWarsPlanet?> GetPlanetAsync(int id);

        Task<StarWarsListResponse<StarWarsFilm>?> GetAllFilmsAsync(int page = 1);
        Task<StarWarsFilm?> GetFilmAsync(int id);

        Task<StarWarsListResponse<StarWarsSpecies>?> GetAllSpeciesAsync(int page = 1);
        Task<StarWarsSpecies?> GetSpeciesAsync(int id);

        Task<StarWarsListResponse<StarWarsVehicle>?> GetAllVehiclesAsync(int page = 1);
        Task<StarWarsVehicle?> GetVehicleAsync(int id);

        Task<StarWarsListResponse<StarWarsStarship>?> GetAllStarshipsAsync(int page = 1);
        Task<StarWarsStarship?> GetStarshipAsync(int id);

    }
}
