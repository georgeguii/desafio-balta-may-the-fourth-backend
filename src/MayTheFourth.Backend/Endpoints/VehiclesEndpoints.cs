using MayTheFourth.Backend.DataBase;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.Endpoints;

public static class VehiclesEndpoints
{
    public static void AddVehiclesEndpoints(this RouteGroupBuilder route)
    {
        var VehiclesRoutes = route.MapGroup("Vehicles");

        VehiclesRoutes.MapGet("/", async ([FromServices] ApiDbContext context) =>
             await context.Vehicles.AsNoTracking().ToListAsync())
        .Produces<List<Vehicle>>(StatusCodes.Status200OK)
        .WithName("GetAllVehicles")
        .WithTags("Vehicle");

        VehiclesRoutes.MapGet("/{id}", async (int id, [FromServices] ApiDbContext context) =>
             await context.Vehicles.FirstOrDefaultAsync(f => f.Id == id)
                is Vehicle Vehicle
                ? Results.Ok(Vehicle)
                : Results.NotFound())
        .Produces<Vehicle>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("GetVehicleById")
        .WithTags("Vehicle");
    }
}
