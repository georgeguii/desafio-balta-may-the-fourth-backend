using MayTheFourth.Backend.Entitites;
using MayTheFourth.SWAPIWrapper;

namespace MayTheFourth.Backend.DataBase
{
    internal class DbInitializer
    {
        internal static async Task Initialize(ApiDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            var wrapperAPI = new StarWarsAPI();

            await Task.WhenAll(
                AddFilmsFromWrapper(dbContext, wrapperAPI),
                AddCharactersFromWrapper(dbContext, wrapperAPI)
            );
            await dbContext.SaveChangesAsync();
        }

        private static async Task AddFilmsFromWrapper(ApiDbContext dbContext, StarWarsAPI wrapperAPI)
        {
            if (dbContext.Films.Any())
                return;

            var page = 1;

            while (true)
            {
                var response = await wrapperAPI.GetAllFilmsAsync(page);

                if (response?.Results?.Any() != true)
                    break;

                var filmsToAdd = response.Results.Select(res => 
                { 
                    var urlsSplitted = res.Url.Split("/");
                
                    return new Film
                    {
                        Id = int.Parse(urlsSplitted[urlsSplitted.Length - 2]),
                        Episode = res.EpisodeId,
                        Title = res.Title,
                        OpeningCrawl = res.OpeningCrawl,
                        Director = res.Director,
                        Producer = res.Producer,
                        ReleaseDate = res.ReleaseDate
                    };
                });

                dbContext.Films.AddRange(filmsToAdd);

                if (string.IsNullOrEmpty(response.Next))
                    break;

                page++;
            }
        }

        private static async Task AddCharactersFromWrapper(ApiDbContext dbContext, StarWarsAPI wrapperAPI)
        {
            if (dbContext.Characters.Any())
                return;

            var page = 1;

            while (true)
            {
                var response = await wrapperAPI.GetAllCharactersAsync(page);

                if (response?.Results?.Any() != true)
                    break;

                var characterToAdd = response.Results.Select(res =>
                {
                    var urlsSplitted = res.Url.Split("/");
                    return new Character
                    {
                        Id = int.Parse(urlsSplitted[urlsSplitted.Length - 2]),
                        Name = res.Name,
                        Height = res.Height,
                        Weight = res.Mass,
                        HairColor = res.HairColor,
                        SkinColor = res.SkinColor,
                        EyeColor = res.EyeColor,
                        BirthYear = res.BirthYear,
                        Gender = res.Gender,
                        Planet = null,
                        Films = null
                    };
                });

                dbContext.Characters.AddRange(characterToAdd);

                if (string.IsNullOrEmpty(response.Next))
                    break;

                page++;
            }
        }

    }
}
