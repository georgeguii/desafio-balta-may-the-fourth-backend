using MayTheFourth.Backend.DataBase;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.Configurations
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services)
        {
            AddDbContext(services);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfiguration();
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration(env);

            if (env.IsDevelopment())
            {
                app.UseSeedDataBase();
            }
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "Database"));
        }

    }
}
