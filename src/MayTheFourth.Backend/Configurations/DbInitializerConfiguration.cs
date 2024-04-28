using MayTheFourth.Backend.DataBase;

namespace MayTheFourth.Backend.Configurations
{
    internal static class DbInitializerExtension
    {
        public static async Task<IApplicationBuilder> UseSeedDataBase(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApiDbContext>();
                await Task.Run(() => DbInitializer.Initialize(context));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return app;
        }
    }
}
