using MayTheFourth.Backend.Configurations;
using MayTheFourth.Backend.DataBase;
using MayTheFourth.Backend.Entitites;
using Microsoft.EntityFrameworkCore;

#region Configurations

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration();

var app = builder.Build();
app.UseApiConfiguration(builder.Environment);

#endregion

#region Endpoints

app.MapGet("/film", async (ApiDbContext context) =>
    await context.Films.AsNoTracking().ToListAsync())
    .Produces<List<Film>>(StatusCodes.Status200OK)
    .WithName("GetFilm")
    .WithTags("Film");

app.MapGet("/film/{id}", async (int id, ApiDbContext context) =>
    await context.Films.FirstOrDefaultAsync(f => f.Id == id)
        is Film film
            ? Results.Ok(film)
            : Results.NotFound())
    .Produces<Film>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("GetFilmById")
    .WithTags("Film");


#endregion

app.Run();

public partial class Program { }