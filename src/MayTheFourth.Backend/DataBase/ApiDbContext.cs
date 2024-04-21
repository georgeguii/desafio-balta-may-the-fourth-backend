using MayTheFourth.Backend.Entitites;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.DataBase
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
    }
}