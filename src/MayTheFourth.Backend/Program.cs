using MayTheFourth.Backend.Configurations;
using MayTheFourth.Backend.Endpoints;

#region Configurations

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration();

var app = builder.Build();
await app.UseApiConfiguration(builder.Environment);

#endregion

#region Endpointss

var mapGroup = app.MapGroup("v1");

mapGroup.AddFilmsEndpoints();
mapGroup.AddCharactersEndpoints();
mapGroup.AddPlanetsEndpoints();
mapGroup.AddSpeciesEndpoints();
mapGroup.AddStarshipsEndpoints();
mapGroup.AddVehiclesEndpoints();

#endregion

app.Run();

public partial class Program { }