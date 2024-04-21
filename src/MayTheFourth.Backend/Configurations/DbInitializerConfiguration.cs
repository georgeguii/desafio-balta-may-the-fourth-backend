using MayTheFourth.Backend.DataBase;

namespace MayTheFourth.Backend.Configurations
{
    internal static class DbInitializerExtension
    {
        public static IApplicationBuilder UseSeedDataBase(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApiDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
}
