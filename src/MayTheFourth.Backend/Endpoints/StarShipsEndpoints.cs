using MayTheFourth.Backend.DataBase;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.Endpoints;

public static class StarshipsEndpoints
{
    public static void AddStarshipsEndpoints(this RouteGroupBuilder route)
    {
        var StarshipsRoutes = route.MapGroup("Starships");

        StarshipsRoutes.MapGet("/", async ([FromServices] ApiDbContext context) =>
             await context.Starships.AsNoTracking().ToListAsync())
        .Produces<List<Starship>>(StatusCodes.Status200OK)
        .WithName("GetAllStarships")
        .WithTags("Starship");

        StarshipsRoutes.MapGet("/{id}", async (int id, [FromServices] ApiDbContext context) =>
             await context.Starships.FirstOrDefaultAsync(f => f.Id == id)
                is Starship Starship
                ? Results.Ok(Starship)
                : Results.NotFound())
        .Produces<Starship>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("GetStarshipById")
        .WithTags("Starship");
    }
}
