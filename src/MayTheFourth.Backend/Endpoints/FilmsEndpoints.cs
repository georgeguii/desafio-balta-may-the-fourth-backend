using MayTheFourth.Backend.DataBase;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.Endpoints;

public static class FilmsEndpoints
{
    public static void AddFilmsEndpoints(this RouteGroupBuilder route)
    {
        var filmsRoutes = route.MapGroup("Films");

        filmsRoutes.MapGet("/", async ([FromServices] ApiDbContext context) =>
            await context.Films.AsNoTracking().ToListAsync())
            .Produces<List<Film>>(StatusCodes.Status200OK)
            .WithName("GetAllFilms")
            .WithTags("Film");

        filmsRoutes.MapGet("/{id}", async (int id, [FromServices] ApiDbContext context) =>
            await context.Films.FirstOrDefaultAsync(f => f.Id == id)
                is Film film
                    ? Results.Ok(film)
                    : Results.NotFound())
            .Produces<Film>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetFilmById")
            .WithTags("Film");
    }
}
