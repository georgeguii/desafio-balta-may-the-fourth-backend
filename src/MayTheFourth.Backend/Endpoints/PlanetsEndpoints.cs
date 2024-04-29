using MayTheFourth.Backend.DataBase;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.Endpoints;

public static class PlanetsEndpoints
{
    public static void AddPlanetsEndpoints(this RouteGroupBuilder route)
    {
        var PlanetsRoutes = route.MapGroup("planets");

        PlanetsRoutes.MapGet("/", async ([FromServices] ApiDbContext context) =>
             await context.Planets.AsNoTracking().ToListAsync())
        .Produces<List<Planet>>(StatusCodes.Status200OK)
        .WithName("GetAllPlanets")
        .WithTags("Planet");

        PlanetsRoutes.MapGet("/{id}", async (int id, [FromServices] ApiDbContext context) =>
             await context.Planets.FirstOrDefaultAsync(f => f.Id == id)
                is Planet Planet
                ? Results.Ok(Planet)
                : Results.NotFound())
        .Produces<Planet>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("GetPlanetById")
        .WithTags("Planet");
    }
}
