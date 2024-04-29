using MayTheFourth.Backend.DataBase;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.Endpoints;

public static class SpeciesEndpoints
{
    public static void AddSpeciesEndpoints(this RouteGroupBuilder route)
    {
        var SpeciesRoutes = route.MapGroup("Species");

        SpeciesRoutes.MapGet("/", async ([FromServices] ApiDbContext context) =>
             await context.Species.AsNoTracking().ToListAsync())
        .Produces<List<Specie>>(StatusCodes.Status200OK)
        .WithName("GetAllSpecies")
        .WithTags("Specie");

        SpeciesRoutes.MapGet("/{id}", async (int id, [FromServices] ApiDbContext context) =>
             await context.Species.FirstOrDefaultAsync(f => f.Id == id)
                is Specie Specie
                ? Results.Ok(Specie)
                : Results.NotFound())
        .Produces<Specie>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("GetSpecieById")
        .WithTags("Specie");
    }
}
