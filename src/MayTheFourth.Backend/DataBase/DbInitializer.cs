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

            await AddFilmsFromWrapper(dbContext, wrapperAPI);
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

                var filmsToAdd = response.Results.Select(res => new Film
                {
                    Id = res.EpisodeId,
                    Episode = res.EpisodeId,
                    Title = res.Title,
                    OpeningCrawl = res.OpeningCrawl,
                    Director = res.Director,
                    Producer = res.Producer,
                    ReleaseDate = res.ReleaseDate
                });

                dbContext.Films.AddRange(filmsToAdd);

                if (string.IsNullOrEmpty(response.Next))
                    break;

                page++;
            }
        }

    }
}
