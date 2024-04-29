using MayTheFourth.Backend.Entitites;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.DataBase
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Starship> Starships { get; set; }
        public DbSet<Specie> Species { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }


    }
}