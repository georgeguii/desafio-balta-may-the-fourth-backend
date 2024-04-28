using MayTheFourth.Backend.DataBase;
using MayTheFourth.Backend.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Backend.Endpoints;

public static class CharactersEndpoints
{
    public static void AddCharactersEndpoints(this RouteGroupBuilder route)
    {
        var charactersRoutes = route.MapGroup("characters");

        charactersRoutes.MapGet("/", async ([FromServices] ApiDbContext context) =>
             await context.Characters.AsNoTracking().ToListAsync())
        .Produces<List<Character>>(StatusCodes.Status200OK)
        .WithName("GetAllCharacters")
        .WithTags("Character");

        charactersRoutes.MapGet("/{id}", async (int id, [FromServices] ApiDbContext context) =>
             await context.Characters.FirstOrDefaultAsync(f => f.Id == id)
                is Character character
                ? Results.Ok(character)
                : Results.NotFound())
        .Produces<Character>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("GetCharacterById")
        .WithTags("Character");
    }
}
