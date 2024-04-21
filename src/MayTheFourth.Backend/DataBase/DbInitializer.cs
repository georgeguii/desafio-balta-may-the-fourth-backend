using MayTheFourth.Backend.Entitites;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.DataBase
{
    internal class DbInitializer
    {
        internal static void Initialize(ApiDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            AddFilm(dbContext);

            dbContext.SaveChanges();
        }

        private static void AddFilm(ApiDbContext dbContext)
        {
            if (dbContext.Films.Any()) return;

            var film = new Film
            {
                Id = 1,
                Title = "The Rise of the Jedi",
                Episode = 10,
                OpeningCrawl = "After the fall of the Empire, the galaxy face...",
                Director = "Jana Doe",
                Producer = "Leo Smith",
                ReleaseDate = new DateTime(2028, 12, 15),
            };
            dbContext.Films.Add(film);

        }
    }
}
