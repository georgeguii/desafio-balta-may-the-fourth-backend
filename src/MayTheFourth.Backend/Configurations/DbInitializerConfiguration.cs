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
                
                var isTestEnvironment = AppDomain.CurrentDomain.GetAssemblies().Any(a => a.GetName().Name.Contains("Test"));
                if (isTestEnvironment) 
                    await DbInitializer.Initialize(context); 
                else 
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
